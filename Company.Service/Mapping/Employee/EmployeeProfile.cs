using AutoMapper;
using Models = Company.Data.Models;
using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Mapping.Employee;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Models.Employee, EmployeeDto>().ReverseMap();
    }
}
