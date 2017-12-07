using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;
using PersonalBudget.Utilities;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController
    {
        private readonly IImporter importer;

        private readonly IUnitOfWork unitOfWork;

        public AdminController(IImporter importer, IUnitOfWork unitOfWork)
        {
            this.importer = importer;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task Import()
        {
            var transactions =
                await importer.ReadTransactionsAsync(@"C:\Dev\Git\PersonalBudget\Main Budget (2) as of 2017-03-02 845 PM-Register.csv");

            var repository = unitOfWork.GetRepository<Transaction>();

            await repository.InsertAsync(transactions);
        }
    }
}
