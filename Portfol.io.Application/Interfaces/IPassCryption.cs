namespace Portfol.io.Application.Interfaces
{
    public interface IPassCryption
    {
        public string Encrypt(string password);
        public bool Verify(string password, string hash);
    }
}
