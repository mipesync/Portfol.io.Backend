using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Common.Exceptions
{
    public class PassNotCorrectException : Exception
    {
        public PassNotCorrectException() :base("The password is not correct.") {}
    }
}
