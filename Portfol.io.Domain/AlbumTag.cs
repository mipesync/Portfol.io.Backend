namespace Portfol.io.Domain
{
    public class AlbumTag
    {
        public Guid AlbumId { get; set; }
        public Guid TagId { get; set; }

        public Album? Album { get; set; }
        public Tag? Tag { get; set; }
    }
}
