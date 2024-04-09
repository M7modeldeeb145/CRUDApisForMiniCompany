using System.ComponentModel.DataAnnotations;

namespace ApiTest.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
