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
        //this is the writer of the articel .
        [Required]
        public ApplicationUser ?ApplicationUser { get; set; }
         }
}
