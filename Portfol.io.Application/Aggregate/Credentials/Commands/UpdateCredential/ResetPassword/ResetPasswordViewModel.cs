namespace Portfol.io.Application.Aggregate.Credentials.Commands.UpdateCredential.ResetPassword
{
    public class ResetPasswordViewModel
    {
        public string Username { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmNewPassword { get; set; } = null!;
        public string VerifyCode { get; set; } = null!;
    }
}
