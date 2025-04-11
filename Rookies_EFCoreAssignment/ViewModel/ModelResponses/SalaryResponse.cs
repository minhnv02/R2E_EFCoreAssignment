using Rookies_EFCoreAssignment.Domain.Entities;

namespace Rookies_EFCoreAssignment.API.ViewModel.ModelResponses
{
    public class SalaryResponse
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public long EmployeeId { get; set; }

        public SalaryResponse(Salary salary)
        {
            Id = salary.Id;
            Amount = salary.Amount;
            EmployeeId = salary.EmployeeId;
        }
    }
}
