namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    public class AlbumsViewModel
    {
        public IEnumerable<AlbumLookupDto> Albums { get; set; } = null!;
    }
}
