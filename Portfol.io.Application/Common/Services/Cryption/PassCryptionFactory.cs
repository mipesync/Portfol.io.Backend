using Portfol.io.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Common.Services.Cryption
{
    public static class PassCryptionFactory
    {
        public static IPassCryption PassCryption()
        {
            return new PassCryption();
        }
    }
}
