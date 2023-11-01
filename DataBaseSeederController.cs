using Microsoft.AspNetCore.Mvc;
using TestDummyApi.Dal;

namespace TestDummyApi.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseSeederController : ControllerBase
    {
        private readonly EmployeeDbContext _apiDbContext;
        public DataBaseSeederController(EmployeeDbContext context)
        {
            _apiDbContext = context;
        }
        [HttpGet]
        [Route("Init")]
        public async Task<IActionResult> Get()
        {
            DataBaseSeeder<EmployeeDbContext> databaseSeeder = new DataBaseSeeder<EmployeeDbContext>();
            var retVal = await databaseSeeder.SetupDatabaseWithTestData(_apiDbContext);//, (x) => _passwordEncryptHelper.ProtectAsync<string>(x).Result);
            return Ok(retVal);
        }
    }
}
