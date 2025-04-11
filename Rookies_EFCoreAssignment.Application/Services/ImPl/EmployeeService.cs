using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using System.Linq.Expressions;

namespace Rookies_EFCoreAssignment.Application.Services.ImPl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees(params Expression<Func<Employee, object>>[] includeProperties)
        {
            return await _employeeRepository.GetAllAsync(null, includeProperties);
        }

        public async Task<Employee> GetEmployee(long id)
        {
            return await _employeeRepository.GetAsync(x => x.Id == id);
        }

        public async Task<Employee> GetEmployee(long id, params Expression<Func<Employee, object>>[] includeProperties)
        {
            return await _employeeRepository.GetAsync(x => x.Id == id, includeProperties);
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            if (employee == null)
                return false;
            await _employeeRepository.AddAsync(employee);
            var isSuccess = await _employeeRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee == null)
                return false;
            var employeeExisted = await _employeeRepository
                .GetAsync(x => x.Id == employee.Id,
                            x => x.Department,
                            x => x.Salary
            );
            if (employeeExisted == null)
                return false;

            employeeExisted.Name = employee.Name;
            employeeExisted.DateOfBirth = employee.DateOfBirth;
            employeeExisted.Email = employee.Email;
            employeeExisted.Phone = employee.Phone;
            employeeExisted.Address = employee.Address;
            employeeExisted.DepartmentId = employee.DepartmentId;
            employeeExisted.JoinDate = employee.JoinDate;
            employeeExisted.Salary.Amount = employee.Salary.Amount;

            _employeeRepository.Update(employeeExisted);
            var isSuccess = await _employeeRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> DeleteEmployee(long id)
        {
            var employee = await _employeeRepository
                .GetAsync(x => x.Id == id);
            if (employee == null)
                return false;
            _employeeRepository.Delete(employee);
            var isSuccess = await _employeeRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<dynamic> GetByQueryAsync(string query)
        {
            return await _employeeRepository.GetByQueryAsync(query);
        }
    }
}
