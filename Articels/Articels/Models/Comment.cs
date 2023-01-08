namespace Articels.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string? _comment { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Articelss Articelss { get; set; }
    }
}
