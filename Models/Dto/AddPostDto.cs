using Bimbrownik_API.Models.Entities;

namespace Bimbrownik_API.Models.Dto
{
    public class AddPostDto
    {

        public required string Name { get; set; }
        public string? Description { get; set; }
        //public required string AuthorId { get; set; }
        public required string Title { get; set; }

        public Guid AlcoholCategoryId { get; set; }

        //public AlcoholCategory? AlcoholCategory { get; set; }
    }
}
