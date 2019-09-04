using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormatLib
{
    public interface IAction
    {
        void Write();
    }

    public class Action : IAction
    {
        public void Write()
        {
            Console.WriteLine("Choose the format ant enter it's number");
            foreach (Format f in Enum.GetValues(typeof(Format)))
            {
                Console.WriteLine(f);
            }
        }
       
        
    }

}
