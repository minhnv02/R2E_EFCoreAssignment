using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Application.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartment(long id);

        Task<bool> CreateDepartment(Department department);

        Task<bool> UpdateDepartment(Department department);

        Task<bool> DeleteDepartment(long id);
    }
}
