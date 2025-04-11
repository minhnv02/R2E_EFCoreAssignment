using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using Rookies_EFCoreAssignment.Infrastructure.Data;

namespace Rookies_EFCoreAssignment.Infrastructure.Repositories
{
    public class ProjectEmployeeRepository : GenericRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        public ProjectEmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
