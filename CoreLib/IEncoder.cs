using NAudio.Wave;
using System.IO;

namespace CoreLib
{
    public interface IEncoder
    {
        Stream Encode(WaveStream output);
    }
}
