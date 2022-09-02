namespace Portfol.io.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Album>? Albums { get; set; }
        public virtual ICollection<AlbumTag>? AlbumTags { get; set; }
    }
}
