using Microsoft.AspNetCore.Mvc;
using Rookies_EFCoreAssignment.Application.Services;
using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.API.ViewModel.ModelResponses;
using Rookies_EFCoreAssignment.API.ViewModel.ModelRequests;
namespace Rookies_EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            if (!departments.Any())
                return NotFound("Don't have any department");
            return Ok(departments.ToList().ConvertAll(dep => new DepartmentResponse(dep)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(long id)
        {
            var department = await _departmentService.GetDepartment(id);
            if (department == null)
                return NotFound("Department not found");
            return Ok(new DepartmentResponse(department));
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentRequest departmentRequest)
        {
            try
            {
                var department = new Department
                {
                    Name = departmentRequest.Name ?? string.Empty,
                    Location = departmentRequest.Location ?? string.Empty
                };
                var isSuccess = await _departmentService.CreateDepartment(department);
                if (!isSuccess)
                    return BadRequest("Add department failed");
                return Ok(new DepartmentResponse(department));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(long id, DepartmentRequest departmentRequest)
        {
            try
            {
                var departmentExisted = await _departmentService.GetDepartment(id);
                if (departmentExisted == null)
                    return NotFound("Department not found");

                departmentExisted.Name = departmentRequest.Name ?? string.Empty;
                departmentExisted.Location = departmentRequest.Location ?? string.Empty;
                var isSuccess = await _departmentService.UpdateDepartment(departmentExisted);
                if (!isSuccess)
                    return BadRequest("Update department failed");
                return Ok(new DepartmentResponse(departmentExisted));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            try
            {
                var departmentExisted = await _departmentService.GetDepartment(id);
                if (departmentExisted == null)
                    return NotFound("Department not found");
                var isSuccess = await _departmentService.DeleteDepartment(id);
                if (!isSuccess)
                    return BadRequest("Delete department failed");
                return Ok("Delete department successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
