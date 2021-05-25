using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursorTP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File.Open("gg1", FileMode.Open);
            }
            catch
            {
            }

            Console.ReadLine();
        }
    }
}
