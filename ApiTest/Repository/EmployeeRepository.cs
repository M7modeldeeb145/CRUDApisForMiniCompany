using ApiTest.Data;
using ApiTest.IRepository;
using ApiTest.Models;

namespace ApiTest.Repository
{
    public class EmployeeRepository : IEmployee
    {
        ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public void Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = context.Employees.Find(id);
            if (delete != null)
            {
                context.Employees.Remove(delete);
                context.SaveChanges();
            }
        }

        public Employee GetById(int id)
        {
            return context.Employees.Find(id);
        }

        public List<Employee> ReadAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employee employee)
        {
            var edit = context.Employees.Find(employee.Id);
            if (edit != null)
            {
                edit.Name = employee.Name;
                edit.Salary = employee.Salary;
                context.SaveChanges();
            }
        }
    }
}
