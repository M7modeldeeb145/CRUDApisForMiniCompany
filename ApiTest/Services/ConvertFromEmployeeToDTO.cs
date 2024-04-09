using ApiTest.DTO;
using ApiTest.Models;

namespace ApiTest.Services
{
    public class ConvertFromEmployeeToDTO
    {
        public static List<EmployeeDTO> ConvertList(List<Employee> employees)
        {
            List<EmployeeDTO> EmployeesDTO = new List<EmployeeDTO>();
            foreach (var item in employees)
            {
                //Mapping
                EmployeeDTO employeDTO = new EmployeeDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Salary = item.Salary,
                    DepartmentId = item.DepartmentId
                };
                EmployeesDTO.Add(employeDTO);
            }

            return EmployeesDTO;    
        }
        public static EmployeeDTO Convert(Employee employee)
        {
            //Mapping
            EmployeeDTO employeDTO = new EmployeeDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };

            return employeDTO;
        }

    }
}
