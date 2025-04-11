using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.Application.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();

        Task<Project> GetProject(long id);

        Task<bool> CreateProject(Project project);

        Task<bool> UpdateProject(Project project);

        Task<bool> DeleteProject(long id);
    }
}
