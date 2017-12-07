using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using PersonalBudget.Utilities;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController
    {
        private readonly IImporter importer;

        public AdminController(IImporter importer)
        {
            this.importer = importer;
        }

        [HttpGet]
        public async Task Import()
        {
            await importer.Import(@"C:\Dev\Git\PersonalBudget\Main Budget (2) as of 2017-03-02 845 PM-Register.csv");
        }
    }
}
