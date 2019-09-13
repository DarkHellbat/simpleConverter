using CoreLib;
using NAudio.MediaFoundation;
using NAudio.Wave;
using NAudio.WindowsMediaFormat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmaLib
{
    public class WmaFormat : IFormat
    {
        public string Name => "WMA";

        public IDecoder Decoder { get; }

        public IEncoder Encoder { get; }

        public ISave Save => throw new NotImplementedException();

        public WmaFormat(WmaEncoder encoder, WmaDecoder decoder)
        {
            Decoder = decoder;
            Encoder = encoder;
        }
    }

    public class WmaDecoder : IDecoder
    {
        public WaveStream Decode(Stream input)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(input))
            {
                return WaveFormatConversionStream.CreatePcmStream(mp3);
            }
        }
    }

    public class WmaEncoder : IEncoder
    {
        public Stream Encode(WaveStream output)
        {

            //throw new NotImplementedException();
            var newStream = new MemoryStream();
            NAudio.WindowsMediaFormat.WmaWriter();
           /* using (LameMP3FileWriter mp3 = new LameMP3FileWriter(newStream, output.WaveFormat, 128))
            {
                output.CopyTo(mp3);
                return mp3;
            }*/
        }
    }
}
