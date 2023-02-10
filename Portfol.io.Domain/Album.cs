using NpgsqlTypes;

namespace Portfol.io.Domain
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public int Views { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserId { get; set; }
        public virtual NpgsqlTsVector SearchVector { get; set; } = null!;
		
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public virtual ICollection<AlbumTag> AlbumTags { get; set; } = new List<AlbumTag>();
        public virtual ICollection<AlbumLike> AlbumLikes { get; set; } = new List<AlbumLike>();
        public virtual ICollection<AlbumBookmark> AlbumBookmarks { get; set; } = new List<AlbumBookmark>();
    }
}
