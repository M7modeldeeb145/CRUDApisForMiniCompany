using ApiTest.Models;

namespace ApiTest.IRepository
{
    public interface IEmployee
    {
        void Delete(int id);
        void Update(Employee employee);
        List<Employee> ReadAll();
        Employee GetById(int id);
        void Create(Employee employee);

    }
}
