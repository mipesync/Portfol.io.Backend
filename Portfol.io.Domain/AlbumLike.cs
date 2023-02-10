using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    public class AlbumLike
    {
        public Guid UserId { get; set; }
        public Guid AlbumId { get; set; }

        [JsonIgnore]
        public Album Album { get; set; } = new Album();
    }
}
