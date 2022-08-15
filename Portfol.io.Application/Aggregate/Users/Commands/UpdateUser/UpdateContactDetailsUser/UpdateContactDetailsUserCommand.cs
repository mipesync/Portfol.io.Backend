using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser.UpdateContactDetailsUser
{
    public class UpdateContactDetailsUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
    }
}
