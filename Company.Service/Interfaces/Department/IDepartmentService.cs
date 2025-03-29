using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Interfaces.Department;

public interface IDepartmentService
{
    DepartmentDto? GetById(int? id);

    IEnumerable<DepartmentDto> GetAll();

    void Add(DepartmentDto entity);

    void Update(DepartmentDto entity);

    void Delete(DepartmentDto entity);
}
