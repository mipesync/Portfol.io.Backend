namespace Portfol.io.Application.Aggregate.Albums.DTO
{
    public class GetAlbumsDto
    {
        public IEnumerable<GetAlbumLookupDto> Albums { get; set; } = null!;
    }
}
