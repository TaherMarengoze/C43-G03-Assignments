using AutoMapper;
using Company.Data.Models;
using Company.Repo.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces.Employee;
using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Services;

public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
{
    public void Add(EmployeeDto entityDto)
    {
        //Employee employee = new()
        //{
        //    Name = entityDto.Name,
        //    Age = entityDto.Age,
        //    Phone = entityDto.Phone,
        //    Email = entityDto.Email,
        //    Salary = entityDto.Salary,
        //    Address = entityDto.Address,
        //    ImageUrl = entityDto.ImageUrl,
        //    HiringDate = entityDto.HiringDate,
        //    DepartmentId = entityDto.DepartmentId,
        //};

        entityDto.ImageUrl = DocumentSettings.UploadFile(entityDto.Image!, "Images");

        var employee = mapper.Map<Employee>(entityDto);

        unitOfWork.EmployeeRepository.Add(employee);
        unitOfWork.Commit();
    }

    public void Delete(EmployeeDto entityDto)
    {
        var employee = mapper.Map<EmployeeDto, Employee>(entityDto); //another method of Mapping

        unitOfWork.EmployeeRepository.Delete(employee);
        unitOfWork.Commit();
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        //return unitOfWork.EmployeeRepository.GetAll()
        //    .Select(e => new EmployeeDto
        //    {
        //        Id = e.Id,
        //        Name = e.Name,
        //        Age = e.Age,
        //        Phone = e.Phone,
        //        Email = e.Email,
        //        Salary = e.Salary,
        //        Address = e.Address,
        //        ImageUrl = e.ImageUrl,
        //        HiringDate = e.HiringDate,
        //        DepartmentId = e.DepartmentId,
        //    });

        return mapper.Map<IEnumerable<EmployeeDto>>(unitOfWork.EmployeeRepository.GetAll());
    }

    public EmployeeDto? GetById(int? id)
    {
        if (id == null)
            return null;

        var employeeEntity = unitOfWork.EmployeeRepository.GetById(id.Value);
        
        if (employeeEntity == null)
            return null;

        return mapper.Map<EmployeeDto?>(employeeEntity);

        //return new EmployeeDto
        //{
        //    Id = employeeEntity.Id,
        //    Name = employeeEntity.Name,
        //    Age = employeeEntity.Age,
        //    Phone = employeeEntity.Phone,
        //    Email = employeeEntity.Email,
        //    Salary = employeeEntity.Salary,
        //    Address = employeeEntity.Address,
        //    ImageUrl = employeeEntity.ImageUrl,
        //    HiringDate = employeeEntity.HiringDate,
        //    DepartmentId = employeeEntity.DepartmentId,
        //};
    }

    public IEnumerable<EmployeeDto> GetByName(string name)
    {
        var employees = unitOfWork.EmployeeRepository.GetByName(name);
        var mappedEmployees = mapper.Map<IEnumerable<EmployeeDto>>(employees);
        return mappedEmployees;

        //return unitOfWork.EmployeeRepository.GetByName(name)
        //    .Select(e => new EmployeeDto
        //    {
        //        Id = e.Id,
        //        Name = e.Name,
        //        Age = e.Age,
        //        Phone = e.Phone,
        //        Email = e.Email,
        //        Salary = e.Salary,
        //        Address = e.Address,
        //        ImageUrl = e.ImageUrl,
        //        HiringDate = e.HiringDate,
        //        DepartmentId = e.DepartmentId,
        //    });
    }

    public void Update(EmployeeDto entity)
    {
        throw new NotImplementedException();
    }
}
