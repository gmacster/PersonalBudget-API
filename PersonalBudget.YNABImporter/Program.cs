using System;
using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using PersonalBudget.Data.DataAccessLayer;
using PersonalBudget.Data.Extensions;
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

            var importer = new YNABCsvImporter();

            var transactions = importer.ReadTransactionsAsync(filename).GetAwaiter().GetResult();

            var serviceProvider = ComposeServiceProvider();
            using (var unitOfWork = serviceProvider.GetService<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<Transaction>();
                repository.InsertAsync(transactions);
                unitOfWork.SaveChanges();
            }
        }

        private static IServiceProvider ComposeServiceProvider()
        {
            return new ServiceCollection()
                .AddPersonalBudgetContext()
                .AddUnitOfWork<PersonalBudgetContext>()
                .BuildServiceProvider();
        }
    }
}
