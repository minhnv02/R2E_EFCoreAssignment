using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rookies_EFCoreAssignment.Domain.Entities
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
