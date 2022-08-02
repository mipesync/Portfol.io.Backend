namespace Portfol.io.Domain
{
    public class AlbumTag
    {
        public int AlbumId { get; set; }
        public int TagId { get; set; }

        public Album? Album { get; set; }
        public Tag? Tag { get; set; }
    }
}
