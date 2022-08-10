using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
    {
        public CreateAlbumCommandValidator()
        {
            RuleFor(createAlbumCommand => createAlbumCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(createAlbumCommand => createAlbumCommand.Model.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(35).WithMessage("The name lenght must not be greater than 35.");

            RuleFor(createAlbumCommand => createAlbumCommand.Model.Description)
                .MaximumLength(500).WithMessage("The description lenght must not be greater than 500.");

            RuleFor(createAlbumCommand => createAlbumCommand.Model.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
