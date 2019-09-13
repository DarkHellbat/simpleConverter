using CoreLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    class ConsoleSelector : IFormatSelector
    {
        public ICollection<IFormat> Formats { get; }

        public IFormat GetFormat(params IFormat[] excludedFormats)
        {
            var formats = Formats.Except<IFormat>(excludedFormats).ToArray();

            for (int i = 0; i < formats.Length; i++)
            {
                Console.WriteLine($"{i+1}. - {formats[i].Name}");
            }

            int result = 0;
            while (!int.TryParse(Console.ReadLine(), out result) && formats.Length > result + 1 && result > 0)
            {
                Console.WriteLine("Select one of the formats");
            }

            return formats[result - 1];
        }

        public ConsoleSelector(ICollection<IFormat> formats)
        {
            Formats = formats;
        }
    }
}
