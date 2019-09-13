﻿using CoreLib;
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

        public ISave Save { get; set; }
        //ISave IFormat.Save { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MP3Format(MP3Encoder encoder, MP3Decoder decoder, Mp3Save save)
        {
            Decoder = decoder;
            Encoder = encoder;
            Save = save;
        }
    }



    public class MP3Decoder : IDecoder
    {
        public WaveStream Decode(Stream input)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(input))
            {
                return WaveFormatConversionStream.CreatePcmStream(mp3);
            }
        }
    }

    public class MP3Encoder : IEncoder
    {
        public Stream Encode(WaveStream output)
        {
            var newStream = new MemoryStream();
            using (LameMP3FileWriter mp3 = new LameMP3FileWriter(newStream, output.WaveFormat, 128))
            {
                output.CopyTo(mp3);
                return mp3;
            }
        }
    }

    public class Mp3Save : ISave
    {
        public void Save(Stream input)
        {
            Mp3Save mp3 = new Mp3Save();// input);
        }
    }
}
