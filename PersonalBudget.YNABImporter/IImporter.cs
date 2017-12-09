using System.Collections.Generic;
using System.Threading.Tasks;

using PersonalBudget.Models;

namespace PersonalBudget.Utilities
{
    public interface IImporter
    {
        Task<IEnumerable<Transaction>> ReadTransactionsAsync(string fileName);
    }
}
