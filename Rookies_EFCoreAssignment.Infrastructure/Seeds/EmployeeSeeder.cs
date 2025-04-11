using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public class EmployeeSeeder : IEntitySeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Employee 1",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Address = "Address 1",
                    Email = "email1@example.com",
                    Phone = "1234567890",
                    JoinDate = new DateTime(2000, 12, 30),
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 2,
                    Name = "Employee 2",
                    DateOfBirth = new DateTime(1991, 2, 2),
                    Address = "Address 2",
                    Email = "email2@example.com",
                    Phone = "1234567891",
                    JoinDate = new DateTime(2002, 11, 29),
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 3,
                    Name = "Employee 3",
                    DateOfBirth = new DateTime(1992, 3, 3),
                    Address = "Address 3",
                    Email = "email3@example.com",
                    Phone = "1234567892",
                    JoinDate = new DateTime(2003, 10, 28),
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 4,
                    Name = "Employee 4",
                    DateOfBirth = new DateTime(1993, 4, 4),
                    Address = "Address 4",
                    Email = "email4@example.com",
                    Phone = "1234567893",
                    JoinDate = new DateTime(2004, 9, 27),
                    DepartmentId = 4,
                },
                new Employee
                {
                    Id = 5,
                    Name = "Employee 5",
                    DateOfBirth = new DateTime(1994, 5, 5),
                    Address = "Address 5",
                    Email = "email5@example.com",
                    Phone = "1234567894",
                    JoinDate = new DateTime(2005, 8, 26),
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 6,
                    Name = "Employee 6",
                    DateOfBirth = new DateTime(1995, 6, 6),
                    Address = "Address 6",
                    Email = "email6@example.com",
                    Phone = "1234567895",
                    JoinDate = new DateTime(2006, 7, 25),
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 7,
                    Name = "Employee 7",
                    DateOfBirth = new DateTime(1996, 7, 7),
                    Address = "Address 7",
                    Email = "email7@example.com",
                    Phone = "1234567896",
                    JoinDate = new DateTime(2007, 6, 24),
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 8,
                    Name = "Employee 8",
                    DateOfBirth = new DateTime(1997, 8, 8),
                    Address = "Address 8",
                    Email = "email8@example.com",
                    Phone = "1234567897",
                    JoinDate = new DateTime(2008, 5, 23),
                    DepartmentId = 4,
                },
                new Employee
                {
                    Id = 9,
                    Name = "Employee 9",
                    DateOfBirth = new DateTime(1998, 9, 9),
                    Address = "Address 9",
                    Email = "email9@example.com",
                    Phone = "1234567898",
                    JoinDate = new DateTime(2009, 4, 22),
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 10,
                    Name = "Employee 10",
                    DateOfBirth = new DateTime(1999, 10, 10),
                    Address = "Address 10",
                    Email = "email10@example.com",
                    Phone = "1234567899",
                    JoinDate = new DateTime(2010, 3, 21),
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 11,
                    Name = "Employee 11",
                    DateOfBirth = new DateTime(2000, 11, 11),
                    Address = "Address 11",
                    Email = "email11@example.com",
                    Phone = "1234567800",
                    JoinDate = new DateTime(2011, 2, 20),
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 12,
                    Name = "Employee 12",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    Address = "Address 12",
                    Email = "email12@example.com",
                    Phone = "1234567801",
                    JoinDate = new DateTime(2012, 1, 19),
                    DepartmentId = 4,
                },
                new Employee
                {
                    Id = 13,
                    Name = "Employee 13",
                    DateOfBirth = new DateTime(2002, 1, 13),
                    Address = "Address 13",
                    Email = "email13@example.com",
                    Phone = "1234567802",
                    JoinDate = new DateTime(2013, 12, 18),
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 14,
                    Name = "Employee 14",
                    DateOfBirth = new DateTime(2003, 2, 14),
                    Address = "Address 14",
                    Email = "email14@example.com",
                    Phone = "1234567803",
                    JoinDate = new DateTime(2014, 11, 17),
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 15,
                    Name = "Employee 15",
                    DateOfBirth = new DateTime(2004, 3, 15),
                    Address = "Address 15",
                    Email = "email15@example.com",
                    Phone = "1234567804",
                    JoinDate = new DateTime(2015, 10, 16),
                    DepartmentId = 3,
                }
            };

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}