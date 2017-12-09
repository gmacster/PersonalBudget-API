using System;
using System.IO;

namespace PersonalBudget.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide a filename.");
                return;
            }

            string filename = args[0];
            if (File.Exists(filename) == false)
            {
                Console.WriteLine("File not found.");
                return;
            }


        }
    }
}
