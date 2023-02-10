using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
        [JsonIgnore]
        public virtual ICollection<AlbumTag> AlbumTags { get; set; } = new List<AlbumTag>();
    }
}
