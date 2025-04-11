using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using Rookies_EFCoreAssignment.Infrastructure.Data;

namespace Rookies_EFCoreAssignment.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<dynamic> GetByQueryAsync(string query)
        {
            return await _context.Employees.FromSqlRaw(query).ToListAsync();
        }
    }
}
