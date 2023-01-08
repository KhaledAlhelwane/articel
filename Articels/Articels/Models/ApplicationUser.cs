using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Articels.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string ?SecoundName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birth { get; set; }
        public string ?Bio { get; set; }
        public byte[]? ProfilePicture { get; set; }
        
    }
}
