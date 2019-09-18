using CoreLib;
using NAudio.Lame;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatLib
{
    public class MP3Format : IFormat
    {
        public string Name => "MP3";

        public IDecoder Decoder { get; }

        public IEncoder Encoder { get; }

        //public ISave Save { get; set; }
        //ISave IFormat.Save { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MP3Format(MP3Encoder encoder, MP3Decoder decoder)
        {
            Decoder = decoder;
            Encoder = encoder;
        }
    }



    public class MP3Decoder : IDecoder
    {
        public WaveStream Decode(Stream input)
        {
            var mp3 = new Mp3FileReader(input);
            return WaveFormatConversionStream.CreatePcmStream(mp3);
        }
    }

    public class MP3Encoder : IEncoder
    {
        public void Encode(WaveStream waveData, Stream outputStream)
        {
            using (LameMP3FileWriter mp3 = new LameMP3FileWriter(outputStream, waveData.WaveFormat, 128))
            { 
                waveData.CopyTo(mp3);
            }
        }
    }
}
