namespace Portfol.io.WebAPI.Models
{
    public class CreateCredentialDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
