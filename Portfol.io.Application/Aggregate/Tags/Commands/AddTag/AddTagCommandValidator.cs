using FluentValidation;

namespace Portfol.io.Application.Aggregate.Tags.Commands.AddTag
{
    public class AddTagCommandValidator : AbstractValidator<AddTagCommand>
    {
        public AddTagCommandValidator()
        {
            RuleFor(addTagCommand => addTagCommand.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }
}
