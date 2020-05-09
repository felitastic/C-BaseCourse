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
            bool outputLine = true;

           foreach(var line in arg)
            {
                if (outputLine)
                {
                    yield return line;
                    outputLine = false;
                }
                else
                {
                    outputLine = true;
                }
            }
        }

        public static IEnumerable<string> MyTake(this IEnumerable<string> arg, int lineCount)
        {
            int writtenLines = 0;

            foreach (var line in arg)
            {
                if (writtenLines < lineCount)
                {                    
                    yield return line;
                    writtenLines += 1;
                }
                else
                {
                    yield break;
                }
            }
        }

        // Ctrl + F5 um Konsole anzuhalten
        static void Main(string[] args)
        {
            //foreach (var line in System.IO.File.ReadAllLines(@"..\..\Program.cs").Every2nd())
            //{
            //    Console.WriteLine(line);
            //}            
            
            //foreach (var line in System.IO.File.ReadAllLines(@"..\..\Program.cs").MyTake(6))
            //{
            //    Console.WriteLine(line);
            //}

            foreach (var line in System.IO.File.ReadAllLines(@"..\..\Program.cs").MyTake(6).Every2nd())
            {
                Console.WriteLine(line);
            }
        }
    }
}
