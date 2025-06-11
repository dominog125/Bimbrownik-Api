using Microsoft.AspNetCore.Identity;

namespace Bimbrownik_API.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid PostId { get; set; }

        public string AuthorId { get; set; }           
        public IdentityUser AuthorUser { get; set; }     
    }
}
