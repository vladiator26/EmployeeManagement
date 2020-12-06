using EmployeeManagement.DAL.Entities;
using EmployeeManagement.DAL.Initialization;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.AppContext
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataBaseInitialization.SeedData(modelBuilder);
        }
    }
}