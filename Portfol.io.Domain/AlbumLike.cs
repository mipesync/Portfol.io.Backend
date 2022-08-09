namespace Portfol.io.Domain
{
    public class AlbumLike
    {
        public Guid UserId { get; set; }
        public int AlbumId { get; set; }

        public User? User { get; set; }
        public Album? Album { get; set; }
    }
}
