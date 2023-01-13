using System.ComponentModel.DataAnnotations;

namespace Articels.ViewModel
{
    public class RoleViewModel
    {
        [Required,StringLength(20)]
        public string Name { get; set; }
        public bool CheckingRole { get; set; }
    }
}
