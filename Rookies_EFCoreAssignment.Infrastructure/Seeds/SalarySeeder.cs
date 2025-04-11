using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public class SalarySeeder : IEntitySeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var salaries = new List<Salary>
            {
                new Salary { Id=1, Amount = 50000, EmployeeId = 1 },
                new Salary { Id=15, Amount = 60000, EmployeeId = 2 },
                new Salary { Id=2, Amount = 55000, EmployeeId = 3 },
                new Salary { Id=3, Amount = 58000, EmployeeId = 4 },
                new Salary { Id=4, Amount = 52000, EmployeeId = 5 },
                new Salary { Id=5, Amount = 53000, EmployeeId = 6 },
                new Salary { Id=6, Amount = 56000, EmployeeId = 7 },
                new Salary { Id=7, Amount = 57000, EmployeeId = 8 },
                new Salary { Id=8, Amount = 54000, EmployeeId = 9 },
                new Salary { Id=9, Amount = 59000, EmployeeId = 10 },
                new Salary { Id=10, Amount = 62000, EmployeeId = 11 },
                new Salary { Id=11, Amount = 61000, EmployeeId = 12 },
                new Salary { Id=12, Amount = 57000, EmployeeId = 13 },
                new Salary { Id=13, Amount = 56000, EmployeeId = 14 },
                new Salary { Id=14, Amount = 60000, EmployeeId = 15 },
            };

            modelBuilder.Entity<Salary>().HasData(salaries);
        }
    }
}