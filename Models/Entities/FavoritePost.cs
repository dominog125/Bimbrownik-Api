using Microsoft.AspNetCore.Identity;

namespace Bimbrownik_API.Models.Entities
{
    public class FavoritePost
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }

     

    }
}