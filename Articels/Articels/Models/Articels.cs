using Microsoft.Build.Framework;

namespace Articels.Models
{
    public class Articelss
    {
        public int ?id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? ArticelBody { get; set; }
       
        public byte[]? ImageOfArticel { get; set; }
        [Required]
        public ApplicationUser ?ApplicationUser { get; set; }
        //public Comment Comment { get; set; }
        //public Openines openines { get; set; }
    }
}
