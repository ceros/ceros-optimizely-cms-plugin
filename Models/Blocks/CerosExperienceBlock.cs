using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace CerosExperienceAddon.Models.Blocks
{
    [ContentType(GUID = "502f37d9-4528-4dac-8b9e-e8340da8b3b8")]
    public class CerosExperienceBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [CultureSpecific]
        public virtual string CerosExperienceURL { get; set; }
        
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [CultureSpecific]
        [Editable(false)]
        public virtual string IFrameHtml { get; set; }
    }
}
