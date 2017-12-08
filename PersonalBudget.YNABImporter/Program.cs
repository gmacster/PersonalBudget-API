using System;
using System.IO;

using Microsoft.Extensions.DependencyInjection;

using PersonalBudget.Models;
using PersonalBudget.Utilities;

namespace PersonalBudget.YNABImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a filename.");
                return;
            }

            string filename = args[0];
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var serviceCollection = new ServiceCollection();

            var startup = new Startup();
            startup.ConfigureServices(serviceCollection);

            var importer = new YNABCsvImporter();

            var transactions = importer.ReadTransactionsAsync(filename).GetAwaiter().GetResult();
        }
    }
}
