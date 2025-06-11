namespace Bimbrownik_API.Models.Dto
{
    public class PostResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Author { get; set; } = null!;
        public string Title { get; set; } = null!;
        public Guid AlcoholCategoryId { get; set; }
        public string AlcoholCategoryName { get; set; } = null!;
    }
}
