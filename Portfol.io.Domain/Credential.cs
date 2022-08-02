namespace Portfol.io.Domain
{
    public class Credential
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
