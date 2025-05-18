using Bimbrownik_API.Models.Entities;

namespace Bimbrownik_API.Models.Dto

{
    public class UpdateCommentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }

    }
}
