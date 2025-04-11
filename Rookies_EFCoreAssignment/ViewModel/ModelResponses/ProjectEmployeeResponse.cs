using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.API.ViewModel.ModelResponses
{
    public class ProjectEmployeeResponse
    {
        public long ProjectId { get; set; }
        public long EmployeeId { get; set; }
        public bool IsWorking { get; set; }

        public ProjectEmployeeResponse(ProjectEmployee projectEmployee)
        {
            ProjectId = projectEmployee.ProjectId;
            EmployeeId = projectEmployee.EmployeeId;
            IsWorking = projectEmployee.IsWorking;
        }
    }
}
