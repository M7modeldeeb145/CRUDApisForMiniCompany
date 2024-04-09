using System.ComponentModel.DataAnnotations;

namespace ApiTest.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
