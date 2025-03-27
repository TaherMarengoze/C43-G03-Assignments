using Company.Data.Models;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        [HttpGet]
        public IActionResult Index(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                var employees = employeeService.GetAll();
                return View(employees);
            }
            else
            {
                var employees = employeeService.GetByName(searchKey);
                return View(employees);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
