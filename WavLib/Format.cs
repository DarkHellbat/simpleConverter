using CoreLib;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavLib
{
    public class WavFormat : IFormat
    {
        public string Name => "WAV";

        public IDecoder Decoder { get; }

        public IEncoder Encoder { get; }

        public WavFormat(WavEncoder encoder, WavDecoder decoder)
        {
            Decoder = decoder;
            Encoder = encoder;
        }
    }



    public class WavDecoder : IDecoder
    {
        public WaveStream Decode(Stream input)
        {
            var wav = new WaveFileReader(input);
            {
                return WaveFormatConversionStream.CreatePcmStream(wav);
            }
        }
    }

    public class WavEncoder : IEncoder
    {
        public void Encode(WaveStream waveData, Stream output)
        {
            var wav = new WaveFileWriter(output, waveData.WaveFormat);
            {
                waveData.CopyTo(wav);
            }
        }
    }
}
