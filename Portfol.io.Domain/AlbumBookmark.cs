using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    public class AlbumBookmark
    {
        public Guid AlbumId { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Album Album { get; set; } = new Album();
    }
}
