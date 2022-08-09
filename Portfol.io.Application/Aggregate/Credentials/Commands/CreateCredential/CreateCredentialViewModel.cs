namespace Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential
{
    public class CreateCredentialViewModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
