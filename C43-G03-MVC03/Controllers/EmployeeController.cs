using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Employee;
using Company.Service.Interfaces.Employee.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController(
        IEmployeeService employeeService,
        IDepartmentService departmentService) : Controller
    {
        public IActionResult Index(string searchKey)
        {
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();

            if (string.IsNullOrWhiteSpace(searchKey))
            {
                employees = employeeService.GetAll();
            }
            else
            {
                employees = employeeService.GetByName(searchKey);
            }

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = departmentService.GetAll();

            ViewBag.Departments = departments;

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            try
            {
                employeeService.Add(employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(employee);
            }
            
        }
    }
}
