using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum
{
    public class LikeAlbumCommandValidator : AbstractValidator<LikeAlbumCommand>
    {
        public LikeAlbumCommandValidator()
        {
            RuleFor(likeAlbumCommand => likeAlbumCommand.AlbumId)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(likeAlbumCommand => likeAlbumCommand.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
