using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;

namespace Rookies_EFCoreAssignment.Application.Services.ImPl
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetProject(long id)
        {
            return await _projectRepository.GetAsync(x => x.Id == id);
        }

        public async Task<bool> CreateProject(Project project)
        {
            if (project == null)
                return false;
            await _projectRepository.AddAsync(project);
            var isSuccess = await _projectRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> UpdateProject(Project project)
        {
            if (project == null)
                return false;
            var projectExisted = await _projectRepository.GetAsync(x => x.Id == project.Id);
            if (projectExisted == null)
                return false;

            projectExisted.Name = project.Name;
            projectExisted.Description = project.Description;
            projectExisted.StartDate = project.StartDate;
            projectExisted.EndDate = project.EndDate;

            _projectRepository.Update(project);
            var isSuccess = await _projectRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> DeleteProject(long id)
        {
            var project = await _projectRepository.GetAsync(x => x.Id == id);
            if (project == null)
                return false;
            _projectRepository.Delete(project);
            var isSuccess = await _projectRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }
    }
}
