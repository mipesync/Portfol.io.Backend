using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
    {
        public UpdateAlbumCommandValidator()
        {
            RuleFor(updateAlbumCommand => updateAlbumCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(updateAlbumCommand => updateAlbumCommand.Model.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(updateAlbumCommand => updateAlbumCommand.Model.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(35).WithMessage("The name lenght must not be greater than 35.");

            RuleFor(updateAlbumCommand => updateAlbumCommand.Model.Description)
                .MaximumLength(500).WithMessage("The description lenght must not be greater than 500.");
        }
    }
}
