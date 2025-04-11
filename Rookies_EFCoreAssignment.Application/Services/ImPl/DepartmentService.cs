using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;

namespace Rookies_EFCoreAssignment.Application.Services.ImPl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _IDepartmentRepository;

        public DepartmentService(IDepartmentRepository IDepartmentRepository)
        {
            _IDepartmentRepository = IDepartmentRepository;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _IDepartmentRepository.GetAllAsync();
        }

        public async Task<Department> GetDepartment(long id)
        {
            return await _IDepartmentRepository.GetAsync(x => x.Id == id);
        }

        public async Task<bool> CreateDepartment(Department department)
        {
            if (department == null)
                return false;
            await _IDepartmentRepository.AddAsync(department);
            var isSuccess = await _IDepartmentRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            if (department == null)
                return false;
            var departmentExisted = await _IDepartmentRepository.GetAsync(x => x.Id == department.Id);
            if (departmentExisted == null)
                return false;

            departmentExisted.Name = department.Name;
            departmentExisted.Location = department.Location;

            _IDepartmentRepository.Update(department);
            var isSuccess = await _IDepartmentRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> DeleteDepartment(long id)
        {
            var department = await _IDepartmentRepository.GetAsync(x => x.Id == id);
            if (department == null)
                return false;
            _IDepartmentRepository.Delete(department);
            var isSuccess = await _IDepartmentRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }
    }
}
