using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApplicationDbContext() 
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options) 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }

    }
}
