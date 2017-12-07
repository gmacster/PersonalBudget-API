using System.Threading.Tasks;

namespace PersonalBudget.Utilities
{
    public interface IImporter
    {
        Task Import(string fileName);
    }
}
