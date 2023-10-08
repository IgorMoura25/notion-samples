using EntityFrameworkCourse.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCourse.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trazer de alguma configuração externa, NÃO deixar hardcode
            const string connectionString = "Server=localhost; Database=EntityFramework; TrustServerCertificate=True; User Id=sa; Password=Cerc@tr0va-sqlserver;pooling=true";

            optionsBuilder
                // Estaremos utilizando Sql Server na seguinte connection String
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasQueryFilter(p => !p.IsActive);
        }
    }
}
