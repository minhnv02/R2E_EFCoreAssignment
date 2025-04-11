using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public class ProjectSeeder : IEntitySeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var projects = new List<Project>() {
                new Project
                {
                    Id = 1,
                    Name = "Project 1",
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 6, 30),
                    Status = "New",
                    Description = "Description for Project 1",
                },
                new Project
                {
                    Id = 2,
                    Name = "Project 2",
                    StartDate = new DateTime(2023, 2, 15),
                    EndDate = new DateTime(2023, 8, 15),
                    Status = "In Progress",
                    Description = "Description for Project 2",
                },
                new Project
                {
                    Id = 3,
                    Name = "Project 3",
                    StartDate = new DateTime(2023, 3, 10),
                    EndDate = new DateTime(2023, 9, 30),
                    Status = "Completed",
                    Description = "Description for Project 3",
                }
            };

            modelBuilder.Entity<Project>().HasData(projects);
        }
    }
}