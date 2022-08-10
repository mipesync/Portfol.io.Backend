using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumViewModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}
