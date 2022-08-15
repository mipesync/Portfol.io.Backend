using FluentValidation;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
    {
        public CreateAlbumCommandValidator()
        {
            RuleFor(createAlbumCommand => createAlbumCommand.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(35).WithMessage("The name lenght must not be greater than 35.");

            RuleFor(createAlbumCommand => createAlbumCommand.Description)
                .MaximumLength(500).WithMessage("The description lenght must not be greater than 500.");

            RuleFor(createAlbumCommand => createAlbumCommand.UserId)
                .NotEqual(Guid.Empty).WithMessage("UserId is required");
        }
    }
}
