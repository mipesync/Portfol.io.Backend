using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
    {
        public UpdateAlbumCommandValidator()
        {
            RuleFor(updateAlbumCommand => updateAlbumCommand.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");

            RuleFor(updateAlbumCommand => updateAlbumCommand.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(35).WithMessage("The name lenght must not be greater than 35.");

            RuleFor(updateAlbumCommand => updateAlbumCommand.Description)
                .MaximumLength(500).WithMessage("The description lenght must not be greater than 500.");
        }
    }
}
