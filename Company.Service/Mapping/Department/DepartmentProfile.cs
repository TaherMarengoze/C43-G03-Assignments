using AutoMapper;
using Company.Service.Interfaces.Department.Dto;
using Models = Company.Data.Models;

namespace Company.Service.Mapping.Department;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Models.Department, DepartmentDto>().ReverseMap();
    }
}
