using ApiTest.DTO;
using ApiTest.IRepository;
using ApiTest.Models;
using ApiTest.Repository;
using ApiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee repository;
        public EmployeeController(IEmployee repository)
        {
            this.repository = repository;   
        }
        [HttpGet]
        public IActionResult GetAll()
        {
             var employees = repository.ReadAll();
             return Ok(ConvertFromEmployeeToDTO.ConvertList(employees));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = repository.GetById(id);
            if(emp != null)
            {
                return Ok(ConvertFromEmployeeToDTO.Convert(emp));
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDTO employee)
        {
            if(ModelState.IsValid)
            {
                var emp = new Employee() 
                {
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId= employee.DepartmentId
                };
                repository.Create(emp);
                return Created($"https://localhost:7055/api/Employee/{emp.Id}", emp);
            }
            return BadRequest();

        }
        [HttpPut]
        public IActionResult Update(EmployeeDTO employee)
        {
            if(ModelState.IsValid)
            {
                var emp = repository.GetById(employee.Id);
                if (emp != null)
                {
                    repository.Update(emp);
                    return Ok(ConvertFromEmployeeToDTO.Convert(emp));
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = repository.GetById(id);
            if (delete != null)
            {
                repository.Delete(id);
                return Ok(ConvertFromEmployeeToDTO.Convert(delete));
            }
            return NotFound();
        }
    }
}
