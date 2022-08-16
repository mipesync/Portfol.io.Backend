namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    public class AlbumsViewModel
    {
        public IEnumerable<AlbumLookupDto> Albums { get; set; } = null!;
    }
}