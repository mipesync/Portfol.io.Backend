namespace Portfol.io.Application.Aggregate.Credentials.Commands.RemoveCredential
{
    public class RemoveCredentialViewModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
    }
}
