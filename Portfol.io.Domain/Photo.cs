using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
        public Guid AlbumId { get; set; }

        [JsonIgnore]
        public virtual Album Album { get; set; } = new Album();
    }
}
