namespace Bimbrownik_API.Models
{
    public class UpdatePostDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public required string Title { get; set; }

    }
}
