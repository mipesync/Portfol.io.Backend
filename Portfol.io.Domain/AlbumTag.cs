namespace Portfol.io.Domain
{
    public class AlbumTag
    {
        public Guid AlbumId { get; set; }
        public Guid TagId { get; set; }

        public Album Album { get; set; } = new Album();
        public Tag Tag { get; set; } = new Tag();
    }
}
