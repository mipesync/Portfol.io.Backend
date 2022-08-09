﻿using FluentValidation;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand => updateUserCommand.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(updateUserCommand => updateUserCommand.Model.Id)
                .NotEqual(Guid.Empty).WithMessage("Id is required");

            RuleFor(updateUserCommand => updateUserCommand.Model.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(updateUserCommand => updateUserCommand.Model.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("The description lenght must be less than 500.");

            RuleFor(updateUserCommand => updateUserCommand.Model.DateOfBirth)
                .NotEqual(default(DateOnly)).WithMessage("DateOfBirth is required");
        }
    }
}