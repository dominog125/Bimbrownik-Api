using Microsoft.AspNetCore.Identity;

namespace Bimbrownik_API.Models.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Title { get; set; }

        public string AuthorId { get; set; }             

        public Guid AlcoholCategoryId { get; set; }
        public AlcoholCategory AlcoholCategory { get; set; }

        public Post() { }
    }
}
