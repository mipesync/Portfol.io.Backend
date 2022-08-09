namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
    }
}
