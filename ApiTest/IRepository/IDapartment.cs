using ApiTest.Models;

namespace ApiTest.IRepository
{
    public interface IDapartment
    {
        void Create(Department department);
        void Update(Department department);
        List<Department> GetAll();
        Department GetById(int id);
        void Delete (int id);
    }
}
