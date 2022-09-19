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

        public virtual ICollection<Photo>? Photos { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        public virtual ICollection<AlbumTag>? AlbumTags { get; set; }
        public virtual ICollection<AlbumLike>? AlbumLikes { get; set; }
        public virtual ICollection<AlbumBookmark>? AlbumBookmarks { get; set; }
    }
}
