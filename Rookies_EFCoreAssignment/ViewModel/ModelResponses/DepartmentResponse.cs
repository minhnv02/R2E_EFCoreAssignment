using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.API.ViewModel.ModelResponses
{
    public class DepartmentResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public DepartmentResponse(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Location = department.Location;
        }
    }
}
