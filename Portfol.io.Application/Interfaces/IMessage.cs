using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Interfaces
{
    public interface IMessage
    {
        void Send();
        string ToAddress { get; set; }
        private string FromAddress { get; set; }
    }
}
