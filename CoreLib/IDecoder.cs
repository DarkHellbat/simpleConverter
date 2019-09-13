using NAudio.Wave;
using System.IO;

namespace CoreLib
{
    public interface IDecoder
    {
        WaveStream Decode(Stream input);  
    }
}
