using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Interfaces
{
    public interface IPassCryption
    {
        public string Encrypt(string password);
        public bool Verify(string password, string hash);
    }
}
