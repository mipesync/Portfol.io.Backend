using Portfol.io.Application.Interfaces;
using Crypt = BCrypt.Net.BCrypt;

namespace Portfol.io.Application.Common.Services.Cryption
{
    public class PassCryption : IPassCryption
    {
        public string Encrypt(string password)
        {
            return Crypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            return Crypt.EnhancedVerify(password, hash);
        }
    }
}
