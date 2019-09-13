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

        public ISave Save { get; set;}
        //ISave IFormat.Save { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WavFormat(WavEncoder encoder, WavDecoder decoder, WavSave save)
        {
            Decoder = decoder;
            Encoder = encoder;
            Save = save;
        }
    }



    public class WavDecoder : IDecoder
    {
        public WaveStream Decode(Stream input)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(input))
            {
                return WaveFormatConversionStream.CreatePcmStream(mp3);
            }
        }
    }

    public class WavEncoder : IEncoder
    {
        public Stream Encode(WaveStream output)
        {
            var newStream = new MemoryStream();
           // using (WaveFileWriter wav = new WaveFileWriter(output, WaveFormat))
            {
                output.CopyTo(newStream);
                return newStream;
            }
        }
    }

    public class WavSave : ISave
    {
        public void Save(Stream input)
        {
            WaveFileWriter writer = new WaveFileWriter(input, new WaveFormat(44100, 2));
            byte[] buffer = new byte[1024];
            //int read;
            //while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
            //{
                writer.Write(buffer, 0, buffer.Length);
            //}
        }
    }
}
