using Employee.Database;
using Employee.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.DataBase
{
    public class EmployeeDbContext : DbContext
    {
        public static string ConnectionString { get; set; } = null!;

        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplySoftDelete();
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Entities.Employee> Employees { get; set; } = null!;
        public DbSet<Wife> Wives { get; set; } = null!;
        public DbSet<Child> Children { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
    }
}
