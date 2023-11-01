using Microsoft.EntityFrameworkCore;
using TestDummyApi.DomainModels;

namespace TestDummyApi.Dal
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<EmployeeDM> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RENOSOFTWARES05\\SQLEXPRESS;database=TestDummyApi;User Id=sa;Password=password;MultipleActiveResultSets=true;Encrypt=False");
            //optionsBuilder.UseSqlServer("Server=192.168.29.71;Database=HeroAPIDB;User Id=sa;Password=123@Reno;MultipleActiveResultSets=true;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
            //For deployment we use below method for database creation
            /*optionsBuilder.UseSqlServer("Server=192.168.29.71;Database=HeroDB;User Id=sa;Password=123@Reno;MultipleActiveResultSets=true;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);*/
        }
    }
}
