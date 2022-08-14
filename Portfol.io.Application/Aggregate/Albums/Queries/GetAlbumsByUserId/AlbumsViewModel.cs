namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class AlbumsViewModel
    {
        public IEnumerable<AlbumLookupDto> Albums { get; set; } = null!;
    }
}