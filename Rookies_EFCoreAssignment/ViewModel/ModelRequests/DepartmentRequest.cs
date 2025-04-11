using System.ComponentModel.DataAnnotations;

namespace Rookies_EFCoreAssignment.API.ViewModel.ModelRequests
{
    public class DepartmentRequest
    {
        public string? Name { get; set; }

        [RegularExpression("Hanoi|HCM|Danang")]
        public string? Location { get; set; }
    }
}
