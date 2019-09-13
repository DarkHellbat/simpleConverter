using Autofac;
using CoreLib;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
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
       // public static ICollection<Format> filters;

        static IContainer ContainerBuild(Assembly assembly)
        {
            var builder = new ContainerBuilder();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(path, "*Lib.dll");

            foreach (var f in files)
            {
                RegisterAssembly(builder, Assembly.LoadFile(f));
                        }

            RegisterAssembly(builder, Assembly.GetCallingAssembly());
            //   builder.RegisterType<Mp3FileReader>().AsSelf().AsImplementedInterfaces();
            return builder.Build();
        }

        private static void RegisterAssembly(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                                .AsSelf()
                                .AsImplementedInterfaces()
                                .SingleInstance();
        }

        [STAThread]
        static void Main(string[] args)
        {
            var container = ContainerBuild(Assembly.GetExecutingAssembly());
            var formatSelector = container.Resolve<IFormatSelector>();

            var sourceFormat = formatSelector.GetFormat();
            //foreach (var f in  sourceFormat.)
                var targetFormat = formatSelector.GetFormat(sourceFormat);
          
            Console.WriteLine("Select file path");
            Console.ReadKey();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = $"{sourceFormat.Name} files (*.{sourceFormat.Name})|*.{sourceFormat.Name}|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
                FileStream file = new FileStream(fileDialog.FileName, FileMode.Open);
                Console.ReadKey();
            //targetFormat;
            //    //Regex format = ;
            //    Read(fileDialog.FileName, fileDialog.FileName.Remove(fileDialog.FileName.Length - 3) + "wav");
            // ConvertToMp3(fileDialog.FileName,fileDialog.FileName.Remove(fileDialog.FileName.Length-3)+"wav");
        }
    }
}
