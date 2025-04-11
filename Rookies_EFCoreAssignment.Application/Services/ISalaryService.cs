using Rookies_EFCoreAssignment.Domain.Entities;
using System.Linq.Expressions;

namespace Rookies_EFCoreAssignment.Application.Services
{
    public interface ISalaryService
    {
        Task<IEnumerable<Salary>> GetSalaries();

        Task<IEnumerable<Salary>> GetSalaries(params Expression<Func<Salary, object>>[] includeProperties);

        Task<Salary> GetSalary(long id);

        Task<Salary> GetSalary(long id, params Expression<Func<Salary, object>>[] includeProperties);

        Task<Salary> GetSalary(Func<Salary, bool> expression, params Expression<Func<Salary, object>>[] includeProperties);

        Task<bool> CreateSalary(Salary salary);

        Task<bool> UpdateSalary(Salary salary);

        Task<bool> DeleteSalary(long id);
    }
}
