using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Interfaces
{
    public interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }
}
