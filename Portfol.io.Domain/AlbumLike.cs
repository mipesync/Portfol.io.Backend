using System.ComponentModel.DataAnnotations;

namespace Portfol.io.Domain
{
    public class AlbumLike
    {
        public Guid UserId { get; set; }
        public Guid AlbumId { get; set; }

        public Album? Album { get; set; }
    }
}
