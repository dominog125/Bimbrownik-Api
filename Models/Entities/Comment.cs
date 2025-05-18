namespace Bimbrownik_API.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}
