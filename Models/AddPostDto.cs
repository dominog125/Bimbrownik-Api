namespace Bimbrownik_API.Models
{
    public class AddPostDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public required string Title { get; set; }
    }
}
