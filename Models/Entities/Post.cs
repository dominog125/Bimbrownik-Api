namespace Bimbrownik_API.Models.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public required string Title { get; set; }
        public Post() { }
           

    }
}
