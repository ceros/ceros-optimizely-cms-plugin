using System.Text.RegularExpressions;
using System.Web;
using EPiServer.Logging;
using Newtonsoft.Json;

public class OEmbedMetadata
{
    public string Type { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string Html { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Provider_Name { get; set; }
    public string Provider_Url { get; set; }
    public string Version { get; set; }
}

public static class CerosHelpers
{
    // URL to the Ceros oEmbed API
    private const string oEmbedBaseUrl = "https://view.ceros.com/oembed";

    // Regular expression to remove the /p/1 from the end of a URL like https://view.ceros.com/account/experience/p/1
    private const string regexPattern = @"(https:\/\/view\.ceros\.com\/[a-zA-Z0-9-_]+\/[a-zA-Z0-9-_]+)(?:.*)$";

    private static EPiServer.Logging.ILogger _log = LogManager.GetLogger(
        typeof(CerosExperienceBlockChangeInitialization)
    );

    public static OEmbedMetadata GetExperienceMetadata(string experienceUrl)
    {
        if (string.IsNullOrWhiteSpace(experienceUrl))
        {
            return null;
        }

        experienceUrl = RemoveUrlParameters(experienceUrl);

        try
        {
            using var httpClient = new HttpClient();
            var uriBuilder = new UriBuilder(oEmbedBaseUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["url"] = experienceUrl;
            uriBuilder.Query = query.ToString();

            var response = httpClient.GetAsync(uriBuilder.ToString()).Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<OEmbedMetadata>(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    private static string RemoveUrlParameters(string experienceUrl)
    {
        var regex = new Regex(regexPattern);
        var match = regex.Match(experienceUrl);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        else
        {
            _log.Information($"Experience URL '{experienceUrl}' isn't valid. Make sure it looks like 'https://view.ceros.com/account/experience'");
            return null;
        }
    }
}
