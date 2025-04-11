using Microsoft.AspNetCore.Mvc;
using Rookies_EFCoreAssignment.API.ViewModel.ModelRequests;
using Rookies_EFCoreAssignment.API.ViewModel.ModelResponses;
using Rookies_EFCoreAssignment.Application.Services;

namespace Rookies_EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("api/salaries")]
    public class SalaryController : Controller
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalaries()
        {
            var salaries = await _salaryService.GetSalaries();
            if (!salaries.Any())
                return NotFound("Don't have any salary");
            return Ok(salaries.ToList().ConvertAll(sal => new SalaryResponse(sal)));
        }

        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetSalaryByEmployee(long id)
        {
            var salary = await _salaryService.GetSalary(x => x.EmployeeId == id);
            if (salary == null)
                return NotFound("Salary not found");
            return Ok(new SalaryResponse(salary));
        }

        [HttpPost("employee/{id}")]
        public async Task<IActionResult> AddSalaryByEmployee(long id, SalaryRequest salaryRequest)
        {
            try
            {
                var salary = await _salaryService.GetSalary(x => x.EmployeeId == id);
                if (salary == null)
                    return NotFound("Salary not found");
                salary.Amount = salaryRequest.Amount;
                var isSuccess = await _salaryService.CreateSalary(salary);
                if (!isSuccess)
                    return BadRequest("Create salary failed");
                return Ok(new SalaryResponse(salary));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("employee/{id}")]
        public async Task<IActionResult> UpdateSalaryByEmployee(long id, SalaryRequest salaryRequest)
        {
            try
            {
                var salary = await _salaryService.GetSalary(x => x.EmployeeId == id);
                if (salary == null)
                    return NotFound("Salary not found");

                salary.Amount = salaryRequest.Amount;
                var isSuccess = await _salaryService.UpdateSalary(salary);
                if (!isSuccess)
                    return BadRequest("Update salary failed");
                return Ok(new SalaryResponse(salary));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
