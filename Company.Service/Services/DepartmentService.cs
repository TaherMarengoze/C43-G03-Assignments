using Company.Data.Models;
using Company.Repo.Interfaces;
using Company.Service.Interfaces;

namespace Company.Service.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository repo;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        repo = departmentRepository;
    }

    public void Add(Department entity)
    {
        var mappedDepartment = new Department
        {
            Code = entity.Code,
            Name = entity.Name,
        };

        repo.Add(mappedDepartment);
    }

    public void Delete(Department entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Department> GetAll()
    {
        var departments = repo.GetAll();
        return departments;
    }

    public Department? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Department entity)
    {
        throw new NotImplementedException();
    }
}
