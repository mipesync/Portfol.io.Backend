using FluentValidation;

namespace Portfol.io.Application.Aggregate.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator()
        {
            RuleFor(deleteTagCommand => deleteTagCommand.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required.");
        }
    }
}
