namespace Portfol.io.Domain
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; } = null!;
    }
}
