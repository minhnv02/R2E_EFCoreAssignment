using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public class ProjectEmployeeSeeder : IEntitySeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var projectEmployees = new List<ProjectEmployee>()
            {
                new ProjectEmployee { ProjectId = 1, EmployeeId = 5, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 6, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 7, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 8, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 9, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 10, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 11, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 12, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 13, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 6, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 14, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 1, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 1, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 1, IsWorking = true },
            };

            modelBuilder.Entity<ProjectEmployee>().HasData(projectEmployees);
        }
    }
}