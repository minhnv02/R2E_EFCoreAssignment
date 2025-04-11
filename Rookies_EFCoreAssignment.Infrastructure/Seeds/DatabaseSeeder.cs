using Microsoft.EntityFrameworkCore;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public class DatabaseSeeder
    {
        private readonly List<IEntitySeeder> _seeders;

        public DatabaseSeeder()
        {
            _seeders = new List<IEntitySeeder>
            {
                new DepartmentSeeder(),
                new EmployeeSeeder(),
                new SalarySeeder(),
                new ProjectSeeder(),
                new ProjectEmployeeSeeder()
            };
        }

        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            foreach (var seeder in _seeders)
            {
                seeder.Seed(modelBuilder);
            }
        }
    }
}