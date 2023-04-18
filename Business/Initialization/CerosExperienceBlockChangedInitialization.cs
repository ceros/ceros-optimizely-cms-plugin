using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Logging;
using EPiServer.Core;
using CerosExperienceAddon.Models.Blocks;

[ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
public class CerosExperienceBlockChangeInitialization : IInitializableModule
{
    private EPiServer.Logging.ILogger _log = LogManager.GetLogger(
        typeof(CerosExperienceBlockChangeInitialization)
    );

    public void Initialize(InitializationEngine context)
    {
        var events = ServiceLocator.Current.GetInstance<IContentEvents>();
        events.SavingContent += OnSavingContent;
    }

    private void OnSavingContent(object sender, EPiServer.ContentEventArgs e)
    {
        _log.Information($"Saving content fired for content {e.ContentLink.ID}");
        if (e.Content is CerosExperienceBlock)
        {
            var block = e.Content as CerosExperienceBlock;
            string experienceUrl = block.CerosExperienceURL;

            if (string.IsNullOrEmpty(experienceUrl))
            {
                // Update the block with a blank string.
                _log.Information($"CerosExperienceBlock: updating block with blank string.");
                block.IFrameHtml = "";
            }
            else
            {
                _log.Information($"Getting Ceros experience metadata for url: {experienceUrl}");
                OEmbedMetadata metadata = CerosHelpers.GetExperienceMetadata(experienceUrl);

                if (metadata == null)
                {
                    _log.Warning("Error retrieving metadata from Ceros Experience oEmbed API.");
                    return;
                }

                // Update the block with the iframe code.
                block.IFrameHtml = metadata.Html;
            }

            // Save the block
            e.Content = block as IContent;
        }
    }

    public void Uninitialize(InitializationEngine context)
    {
        var events = ServiceLocator.Current.GetInstance<IContentEvents>();
        events.SavingContent -= OnSavingContent;
    }
}
