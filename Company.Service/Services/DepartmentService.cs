using Company.Data.Models;
using Company.Repo.Interfaces;
using Company.Service.Interfaces;

namespace Company.Service.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(Department entity)
    {
        var mappedDepartment = new Department
        {
            Code = entity.Code,
            Name = entity.Name,
        };

        _unitOfWork.DepartmentRepository.Add(mappedDepartment);
        _unitOfWork.Commit();
    }

    public void Delete(Department entity)
    {
        _unitOfWork.DepartmentRepository.Delete(entity);
        _unitOfWork.Commit();
    }

    public IEnumerable<Department> GetAll()
    {
        var departments = _unitOfWork.DepartmentRepository.GetAll();
        return departments;
    }

    public Department? GetById(int? id)
    {
        if (id is null)
        {
            return null;
        }

        Department? department = _unitOfWork.DepartmentRepository.GetById(id.Value);

        if (department is null)
        {
            return null;
        }

        return department;
    }

    public void Update(Department entity)
    {
        _unitOfWork.DepartmentRepository.Update(entity);
        _unitOfWork.Commit();
    }
}
