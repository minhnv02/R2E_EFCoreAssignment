using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using Rookies_EFCoreAssignment.Infrastructure.Data;

namespace Rookies_EFCoreAssignment.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Project> GetProjectWithEmployeesAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.ProjectEmployees)
                    .ThenInclude(pe => pe.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsWithEmployeesAsync()
        {
            return await _context.Projects
                .Include(p => p.ProjectEmployees)
                    .ThenInclude(pe => pe.Employee)
                .ToListAsync();
        }
    }
}
