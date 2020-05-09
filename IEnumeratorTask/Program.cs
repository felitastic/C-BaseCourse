using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratorTask
{
    static class Program
    {
        public static IEnumerable<string> Every2nd(this IEnumerable<string> arg)
        {           
            return new MyEnumerable(arg);
        }

        public static IEnumerable<string> MyTake(this IEnumerable<string> arg, int lineCount)
        {
            return new MyEnumerable2(arg, lineCount);
        }

        // Ctrl + F5 um Konsole anzuhalten
        static void Main(string[] args)
        {
            //foreach (var line in System.IO.File.ReadAllLines(@"..\..\Program.cs").Every2nd())
            //{
            //    Console.WriteLine(line);
            //   
            //}

            foreach(var line in System.IO.File.ReadAllLines(@"..\..\Program.cs").MyTake(6).Every2nd())
            {
                Console.WriteLine(line);
            }
        }
    }
}
