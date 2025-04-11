using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public class DepartmentSeeder : IEntitySeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var departments = new List<Department>()
            {
                new Department { Id = 1, Name = "Software Development", Location="Hanoi" },
                new Department { Id = 2, Name = "Finance", Location = "Danang" },
                new Department { Id = 3, Name = "Accountant", Location = "Hanoi" },
                new Department { Id = 4, Name = "Human Resource", Location = "HCM" }
            };

            modelBuilder.Entity<Department>().HasData(departments);
        }
    }
}