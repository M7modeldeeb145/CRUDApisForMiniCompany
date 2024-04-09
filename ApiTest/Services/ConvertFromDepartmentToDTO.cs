using ApiTest.DTO;
using ApiTest.Models;

namespace ApiTest.Services
{
    public class ConvertFromDepartmentToDTO
    {
        public static List<DepartmentDTO> ConvertList(List<Department> departments)
        {
            List<DepartmentDTO> departmentsDTO = new List<DepartmentDTO>();
            foreach (Department department in departments)
            {
                DepartmentDTO departmentDTO = new DepartmentDTO()
                {
                    Description = department.Description,
                    Name = department.Name,
                };
                departmentsDTO.Add(departmentDTO);
            }
            return departmentsDTO;
        }
        public static DepartmentDTO Convert(Department department)
        {
            DepartmentDTO departmentDTO = new DepartmentDTO()
            {
                Name = department.Name,
                Description = department.Description,
            };
            return departmentDTO;
        }
    }
}
