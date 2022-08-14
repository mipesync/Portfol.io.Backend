using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum
{
    public class RemoveAlbumCommandValidator : AbstractValidator<RemoveAlbumCommand>
    {
        public RemoveAlbumCommandValidator()
        {
            RuleFor(removeAlbumCommand => removeAlbumCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(removeAlbumCommand => removeAlbumCommand.Model.Id)
                .NotEqual(0).WithMessage("Id is required");

            RuleFor(removeAlbumCommand => removeAlbumCommand.Model.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
