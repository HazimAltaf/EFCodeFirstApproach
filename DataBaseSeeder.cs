using Microsoft.EntityFrameworkCore;
using TestDummyApi.DomainModels;

namespace TestDummyApi.Dal
{
    public class DataBaseSeeder<T> where T : DbContext
    {
        public async Task<bool> SetupDatabaseWithTestData(T context)
        {
            var defaultCreatedBy = "SeedAdmin";
            var defaultUpdatedBy = "UpdateAdmin";
            var apiDb = context as EmployeeDbContext;
            if (apiDb != null)
            {
                SeedDummyEmployee(apiDb, defaultCreatedBy, defaultUpdatedBy);

                return true;
            }
            return false;
        }

        private void SeedDummyEmployee(EmployeeDbContext apiDb, string defaultCreatedBy, string defaultUpdatedBy)
        {
            var employee = new EmployeeDM()
            {
                FirstName = "Nadeem",
                LastName = "Altaf",
                DateOfBirth = DateTime.Today,
                PhoneNumber = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
            };
            apiDb.Employees.Add(employee);
            apiDb.SaveChanges();
        }
    }
}
