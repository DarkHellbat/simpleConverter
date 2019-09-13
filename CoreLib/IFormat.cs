using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public interface IFormat
    {
        string Name { get; }
        IDecoder Decoder { get; }
        IEncoder Encoder { get; }
        ISave Save { get; set; }
    }
}
