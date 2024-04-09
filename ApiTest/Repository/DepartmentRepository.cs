using ApiTest.Data;
using ApiTest.IRepository;
using ApiTest.Models;

namespace ApiTest.Repository
{
    public class DepartmentRepository : IDapartment
    {
        ApplicationDbContext context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Department department)
        {
            context.Add(department);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dep =context.Departments.Find(id);
            if (dep != null)
            {
                context.Departments.Remove(dep);
                context.SaveChanges();
            }
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.Find(id);
        }
        public void Update(Department department)
        {
            var dep = context.Departments.Find(department.Id);
            if (dep != null)
            {
                dep.Name  = department.Name;
                dep.Description = department.Description;
                context.SaveChanges();
            }
        }
    }
}
