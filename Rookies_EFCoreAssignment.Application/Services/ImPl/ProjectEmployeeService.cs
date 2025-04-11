using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;

namespace Rookies_EFCoreAssignment.Application.Services.ImPl
{
    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        public ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployees()
        {
            return await _projectEmployeeRepository.GetAllAsync();
        }

        public async Task<ProjectEmployee> GetProjectEmployee(long employeeId, long projectId)
        {
            return await _projectEmployeeRepository.GetAsync(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployeesByProject(long projectId)
        {
            return await _projectEmployeeRepository.GetAllAsync(x => x.ProjectId == projectId);
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployeesByEmployee(long employeeId)
        {
            return await _projectEmployeeRepository.GetAllAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<bool> CreateProjectEmployee(ProjectEmployee projectEmployee)
        {
            if (projectEmployee == null)
                return false;
            await _projectEmployeeRepository.AddAsync(projectEmployee);
            var isSuccess = await _projectEmployeeRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> UpdateProjectEmployee(ProjectEmployee projectEmployee)
        {
            if (projectEmployee == null)
                return false;
            var projectEmployeeExisted = await _projectEmployeeRepository.GetAsync(x => x.EmployeeId == projectEmployee.EmployeeId && x.ProjectId == projectEmployee.ProjectId);
            if (projectEmployeeExisted == null)
                return false;

            projectEmployeeExisted.IsWorking = projectEmployee.IsWorking;

            _projectEmployeeRepository.Update(projectEmployee);
            var isSuccess = await _projectEmployeeRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> DeleteProjectEmployee(long employeeId, long projectId)
        {
            var projectEmployee = await _projectEmployeeRepository.GetAsync(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
            if (projectEmployee == null)
                return false;
            _projectEmployeeRepository.Delete(projectEmployee);
            var isSuccess = await _projectEmployeeRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }
    }
}
