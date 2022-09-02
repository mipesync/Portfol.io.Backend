using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum
{
    public class RemoveAlbumCommandValidator : AbstractValidator<RemoveAlbumCommand>
    {
        public RemoveAlbumCommandValidator()
        {
            RuleFor(removeAlbumCommand => removeAlbumCommand.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");
        }
    }
}
