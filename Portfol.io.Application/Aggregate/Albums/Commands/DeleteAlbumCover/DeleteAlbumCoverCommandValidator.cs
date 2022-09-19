using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DeleteAlbumCover
{
    public class DeleteAlbumCoverCommandValidator : AbstractValidator<DeleteAlbumCoverCommand>
    {
        public DeleteAlbumCoverCommandValidator()
        {
            RuleFor(u => u.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");

            RuleFor(u => u.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");

            RuleFor(u => u.WebRootPath)
                .NotEmpty().WithMessage("WebRootPath is required");
        }
    }
}
