using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DislikeAlbum
{
    public class DislikeAlbumValidator : AbstractValidator<DislikeAlbumCommand>
    {
        public DislikeAlbumValidator()
        {
            RuleFor(dislikeAlbumCommand => dislikeAlbumCommand.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");

            RuleFor(dislikeAlbumCommand => dislikeAlbumCommand.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
