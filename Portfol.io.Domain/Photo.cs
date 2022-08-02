namespace Portfol.io.Domain
{
    public class Photo
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; } = null!;
    }
}
