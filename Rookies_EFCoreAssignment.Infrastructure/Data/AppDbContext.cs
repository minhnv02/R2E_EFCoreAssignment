using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Infrastructure.Data.Seeds;

namespace Rookies_EFCoreAssignment.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>()
            .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable(t => t.HasCheckConstraint("CK_Project_StartDate_EndDate", "StartDate < EndDate"));
                entity.Property(p => p.Status).HasDefaultValue("New");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable(t => t.HasCheckConstraint("CK_Salary_Amount", "Amount > 0"));
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable(t => t.HasCheckConstraint("CK_Department_Location", "Location IN ('Hanoi', 'HCM', 'Danang')"));
                entity.Property(d => d.Location).HasDefaultValue("Hanoi");
            });

            new DatabaseSeeder().SeedDatabase(modelBuilder);
        }
    }
}