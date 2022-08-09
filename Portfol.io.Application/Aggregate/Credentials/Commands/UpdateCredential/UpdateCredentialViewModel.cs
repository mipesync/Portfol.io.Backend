namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential
{
    public class UpdateCredentialViewModel
    {
        public string OldUsername { get; set; } = null!;
        public string NewUsername { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
    }
}
