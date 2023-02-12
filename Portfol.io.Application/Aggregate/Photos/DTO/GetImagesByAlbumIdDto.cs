namespace Portfol.io.Application.Aggregate.Photos.DTO
{
    public class GetImagesByAlbumIdDto
    {
        public ICollection<ImageLookupDto>? Images { get; set; }
    }
}
