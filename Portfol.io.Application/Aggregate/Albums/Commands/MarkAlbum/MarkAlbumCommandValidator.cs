using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.MarkAlbum
{
    public class MarkAlbumCommandValidator : AbstractValidator<MarkAlbumCommand>
    {
        public MarkAlbumCommandValidator()
        {
            RuleFor(markAlbumCommand => markAlbumCommand.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");

            RuleFor(markAlbumCommand => markAlbumCommand.AlbumId)
                .NotEqual(Guid.Empty).WithMessage("AlbumId is required");
        }
    }
}
