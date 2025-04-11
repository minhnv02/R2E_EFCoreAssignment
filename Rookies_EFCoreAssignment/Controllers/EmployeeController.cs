using Microsoft.AspNetCore.Mvc;
using Rookies_EFCoreAssignment.Application.Services;
using Rookies_EFCoreAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.API.ViewModel.ModelResponses;
using Rookies_EFCoreAssignment.API.ViewModel.ModelRequests;
using Rookies_EFCoreAssignment.Infrastructure.Data;
using static Rookies_EFCoreAssignment.API.ViewModel.ModelResponses.EmployeeResponse;

namespace Rookies_EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly AppDbContext _context;

        public EmployeeController(IEmployeeService employeeService, AppDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            if (!employees.Any())
                return NotFound("Don't have any employee");
            return Ok(employees.ToList().ConvertAll(emp => new EmployeeResponse(emp)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(long id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
                return NotFound("Employee not found");
            return Ok(new EmployeeResponse(employee));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequest employeeRequest)
        {
            try
            {
                var employee = new Employee
                {
                    Name = employeeRequest.Name,
                    DateOfBirth = DateTime.Parse(employeeRequest.DateOfBirth ?? string.Empty),
                    Address = employeeRequest.Address,
                    Email = employeeRequest.Email,
                    Phone = employeeRequest.Phone,
                    JoinDate = DateTime.Parse(employeeRequest.JoinDate ?? string.Empty),
                    DepartmentId = employeeRequest.DepartmentId,
                    Salary = new Salary
                    {
                        Amount = employeeRequest.Salary
                    }
                };
                var addedEmployee = await _employeeService.CreateEmployee(employee);
                if (!addedEmployee)
                    return BadRequest("Add employee failed");
                return Ok("Add employee successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(long id, EmployeeRequest employeeRequest)
        {
            try
            {
                var employeeExisted = await _employeeService.GetEmployee(id);
                if (employeeExisted == null)
                    return NotFound("Employee not found");

                var employee = new Employee
                {
                    Id = id,    
                    Name = employeeRequest.Name,
                    DateOfBirth = DateTime.Parse(employeeRequest.DateOfBirth ?? string.Empty),
                    Address = employeeRequest.Address,
                    Email = employeeRequest.Email,
                    Phone = employeeRequest.Phone,
                    JoinDate = DateTime.Parse(employeeRequest.JoinDate ?? string.Empty),
                    DepartmentId = employeeRequest.DepartmentId,
                    Salary = new Salary
                    {
                        Amount = employeeRequest.Salary
                    }
                };
                var updatedEmployee = await _employeeService.UpdateEmployee(employee);
                if (!updatedEmployee)
                    return BadRequest("Update employee failed");
                return Ok("Update employee successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                if (employee == null)
                    return NotFound("Employee not found");
                var deletedEmployee = await _employeeService.DeleteEmployee(id);
                if (!deletedEmployee)
                    return BadRequest("Delete employee failed");
                return Ok("Delete employee successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("employees-department")]
        public async Task<IActionResult> GetEmployeesDepartment()
        {
            var employeesWithDepartment = await _context.Employees
            .Include(e => e.Department)
            .Select(e => new
            {
                e.Id,
                e.Name,
                e.DateOfBirth,
                e.Address,
                e.Email,
                e.Phone,
                e.JoinDate,
                DepartmentName = e.Department.Name
            })
            .ToListAsync();

            if (!employeesWithDepartment.Any())
            {
                return NotFound("Not found");
            }
            return Ok(employeesWithDepartment);
        }

        [HttpGet("employees-projects")]
        public async Task<IActionResult> GetEmployeesProjects()
        {
            var employeesWithProjects = await _context.Employees
            .Include(e => e.ProjectEmployees)
                .ThenInclude(pe => pe.Project)
            .Select(e => new
            {
                e.Id,
                e.Name,
                e.DateOfBirth,
                e.Address,
                e.Email,
                e.Phone,
                e.JoinDate,
                Projects = e.ProjectEmployees.Select(pe => new
                {
                    pe.Project.Id,
                    pe.Project.Name,
                    pe.Project.StartDate,
                    pe.Project.EndDate,
                    pe.Project.Status,
                    pe.Project.Description
                }).ToList()
            })
            .ToListAsync();

            return Ok(employeesWithProjects);
        }

        [HttpGet("filter/{salary}/{joinDate}")]
        public async Task<IActionResult> GetEmployeesSalary(decimal salary, DateTime joinDate)
        {
            var emps = _context.Database
                .SqlQueryRaw<EmployeeSalaryResponse>
                (@"select e.*, d.Name as DepartmentName, s.Amount as Salary
                    from Employees e
                    join Salaries s on e.Id = s.EmployeeId
                    join Departments d on e.DepartmentId = d.Id
                    where s.Amount > {0} and e.JoinDate >= {1}", salary, joinDate);
            return Ok(emps);
        }
    }
}
