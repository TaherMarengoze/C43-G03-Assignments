using Company.Data.Models;

namespace Company.Service.Interfaces
{
    internal interface IEmployeeService
    {
        Employee? GetById(int id);

        IEnumerable<Employee> GetAll();

        void Add(Employee entity);

        void Update(Employee entity);

        void Delete(Employee entity);
    }
}
