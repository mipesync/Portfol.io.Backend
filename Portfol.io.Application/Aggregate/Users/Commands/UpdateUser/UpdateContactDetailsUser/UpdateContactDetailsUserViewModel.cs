namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUser.UpdateContactDetailsUser
{
    public class UpdateContactDetailsUserViewModel
    {
        public Guid Id { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
    }
}
