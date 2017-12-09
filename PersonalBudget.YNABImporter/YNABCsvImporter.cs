using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

using CsvHelper;

using PersonalBudget.Models;

namespace PersonalBudget.Utilities
{
    public sealed class YNABCsvImporter : IImporter
    {
        public async Task<IEnumerable<Transaction>> ReadTransactionsAsync(string fileName)
        {
            var masterCategoryCache = new Dictionary<string, MasterCategory>();
            var categoryCache = new Dictionary<string, Category>();
            var accountCache = new Dictionary<string, Account>();

            var transactions = new List<Transaction>();

            using (var file = new StreamReader(fileName))
            using (var csv = new CsvReader(file))
            {
                await csv.ReadAsync();
                csv.ReadHeader();

                while (await csv.ReadAsync())
                {
                    var masterCategoryName = csv.GetField<string>("Master Category");

                    // TODO: how to handle account transfers (transactions with an empty category)?
                    // TODO: how to handle hidden categories?
                    // TODO: how to handle Income?
                    if (string.IsNullOrEmpty(masterCategoryName)
                        || masterCategoryName.Equals("Hidden Categories", StringComparison.OrdinalIgnoreCase)
                        || masterCategoryName.Equals("Income", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var masterCategory = masterCategoryCache.GetOrAdd(
                        masterCategoryName,
                        name => new MasterCategory { Name = masterCategoryName });

                    var categoryName = csv.GetField<string>("Sub Category");
                    var category = categoryCache.GetOrAdd(
                        categoryName,
                        name => new Category { Name = name, MasterCategory = masterCategory });

                    var accountName = csv.GetField<string>("Account");
                    var account = accountCache.GetOrAdd(accountName, name => new Account { Name = name });

                    decimal inflow = decimal.Parse(
                        csv.GetField<string>("Inflow"),
                        NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    decimal outflow = decimal.Parse(
                        csv.GetField<string>("Outflow"),
                        NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    transactions.Add(
                        new Transaction
                        {
                            Account = account,
                            Category = category,
                            Date = csv.GetField<DateTime>("Date"),
                            Description = csv.GetField<string>("Memo"),
                            Inflow = inflow,
                            Outflow = outflow,
                            Payee = csv.GetField<string>("Payee")
                        });
                }
            }

            return transactions;
        }
    }
}