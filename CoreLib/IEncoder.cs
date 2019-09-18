using NAudio.Wave;
using System.IO;

namespace CoreLib
{
    public interface IEncoder
    {
        void Encode(WaveStream waveData, Stream outputStream);
    }

    public static class EncoderExtensions
    {
        public static Stream Encode(this IEncoder encoder, WaveStream output)
        {
            var newStream = new MemoryStream();
            encoder.Encode(output, newStream);
            return newStream;
        }
    }
}
