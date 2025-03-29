using AutoMapper;
using Company.Data.Models;
using Company.Repo.Interfaces;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void Add(DepartmentDto departmentDto)
    {
        var mappedDepartment = _mapper.Map<Department>(departmentDto);

        _unitOfWork.DepartmentRepository.Add(mappedDepartment);
        _unitOfWork.Commit();
    }

    public void Delete(DepartmentDto departmentDto)
    {
        var mappedDepartment = _mapper.Map<Department>(departmentDto);
        _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
        _unitOfWork.Commit();
    }

    public IEnumerable<DepartmentDto> GetAll()
    {
        var departments = _unitOfWork.DepartmentRepository.GetAll();
        var mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        return mappedDepartments;
    }

    public DepartmentDto? GetById(int? id)
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

        return _mapper.Map<DepartmentDto?>(department);
    }

    public void Update(DepartmentDto entity)
    {
        //_unitOfWork.DepartmentRepository.Update(entity);
        //_unitOfWork.Commit();
    }
}
