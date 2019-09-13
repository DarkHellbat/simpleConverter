
using CoreLib;
using NAudio.Wave;
using NAudio.Flac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlacLib
{
    public class FlacFormat : IFormat
    {
        public string Name => "FLAC";

        public IDecoder Decoder { get; }

        public IEncoder Encoder { get; }

        public ISave Save => throw new NotImplementedException();

        public FlacFormat(FlacEncoder encoder, FlacDecoder decoder)
        {
            Decoder = decoder;
            Encoder = encoder;
        }
    }

    public class FlacEncoder : IEncoder
    {
        public Stream Encode(WaveStream output)
        {
            
            //    var newStream = new MemoryStream();
            //using (LameMP3FileWriter mp3 = new LameMP3FileWriter(newStream, output.WaveFormat, 128))
            //{
            //    output.CopyTo(mp3);
            //    return mp3;
            //}
        }
    }

    public class FlacDecoder : IDecoder
    {
        public WaveStream Decode(Stream input)
        {
            using (Mp3FileReader flac = new Mp3FileReader(input))
            {
                return WaveFormatConversionStream.CreatePcmStream(flac);
            }
            //throw new NotImplementedException();
        }
    }
}
