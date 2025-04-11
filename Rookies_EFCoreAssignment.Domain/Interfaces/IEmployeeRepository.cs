using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<dynamic> GetByQueryAsync(string query);
    }
}
