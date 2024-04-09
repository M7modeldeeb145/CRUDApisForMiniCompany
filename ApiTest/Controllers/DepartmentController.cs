using ApiTest.DTO;
using ApiTest.IRepository;
using ApiTest.Models;
using ApiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDapartment repository;
        public DepartmentController(IDapartment repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = repository.GetAll();
            return Ok(ConvertFromDepartmentToDTO.ConvertList(departments));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = repository.GetById(id);
            return Ok(ConvertFromDepartmentToDTO.Convert(department));
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO department)
        {
            if(ModelState.IsValid)
            {
                var dept = new Department()
                {
                    Name = department.Name,
                    Description = department.Description
                };
                repository.Create(dept);
                return Created($"https://localhost:7055/api/Department/{dept.Id}",dept);
                
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(DepartmentDTO department)
        {
            if(ModelState.IsValid)
            {
                var dep = repository.GetById(department.Id);
                if (dep != null)
                {
                    repository.Update(dep);
                    return Ok(ConvertFromDepartmentToDTO.Convert(dep));
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        [HttpDelete] public IActionResult Delete(int id)
        {
            var dept = repository.GetById(id);
            if (dept != null)
            {
                repository.Delete(id);
                return Ok(ConvertFromDepartmentToDTO.Convert(dept));
            }
            return NotFound();
        }
    }
}
