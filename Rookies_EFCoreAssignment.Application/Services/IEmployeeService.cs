using Rookies_EFCoreAssignment.Domain.Entities;
using System.Linq.Expressions;

namespace Rookies_EFCoreAssignment.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<IEnumerable<Employee>> GetEmployees(params Expression<Func<Employee, object>>[] includeProperties);

        Task<Employee> GetEmployee(long id);

        Task<Employee> GetEmployee(long id, params Expression<Func<Employee, object>>[] includeProperties);

        Task<bool> CreateEmployee(Employee employee);

        Task<bool> UpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(long id);

        Task<dynamic> GetByQueryAsync(string query);
    }
}
