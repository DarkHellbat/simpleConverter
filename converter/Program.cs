using Autofac;
using FormatLib;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace converter
{
    class Program
    {
        static IContainer ContainerBuild(Assembly assembly)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Format)))
               // .Where(x => !x.IsInterface)
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

         //   builder.RegisterType<Mp3FileReader>().AsSelf().AsImplementedInterfaces();
            return builder.Build();
        }
       [STAThread] static void Main(string[] args)
        {
            // using 
            var container = ContainerBuild(Assembly.GetExecutingAssembly());

           // var somevar = container.Resolve<IMp3FileReader>

            Console.WriteLine("Select file path");
            Console.ReadKey();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                //Regex format = ;
                using (container)
                {
                    var write = container.Resolve<IAction>();
                    write.Write();
                }
                    Read(fileDialog.FileName, fileDialog.FileName.Remove(fileDialog.FileName.Length - 3) + "wav");
           // ConvertToMp3(fileDialog.FileName,fileDialog.FileName.Remove(fileDialog.FileName.Length-3)+"wav");
        }
        private static void ConvertToMp3(string startPath, string resultPath)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(startPath))
            {
                using (WaveStream wav = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(resultPath, wav);
                }
            }
        }
        public static void Read(string startPath, string resultPath)
        {
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":

                    break;
                case "2":
                    ConvertToMp3(startPath, resultPath);
                    break;
            }
        }

    }
}
