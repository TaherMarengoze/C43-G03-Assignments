using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Company.Repo.Interfaces;
using Company.Service.Interfaces;

namespace Company.Service.Services;

public class EmployeeService(IUnitOfWork unitOfWork) : IEmployeeService
{
    public void Add(Employee entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Employee entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> GetAll()
    {
        return unitOfWork.EmployeeRepository.GetAll();
    }

    public Employee? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> GetByName(string name)
    {
        return unitOfWork.EmployeeRepository.GetByName(name);
    }

    public void Update(Employee entity)
    {
        throw new NotImplementedException();
    }
}
