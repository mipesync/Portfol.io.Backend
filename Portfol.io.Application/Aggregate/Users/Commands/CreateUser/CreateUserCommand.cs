using MediatR;

namespace Portfol.io.Application.Aggregate.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public int CredentialsId { get; set; }
        public int RoleId { get; set; }
    }
}
