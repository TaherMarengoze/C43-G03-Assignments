using Company.Data.Models;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var depts = _departmentService.GetAll();

            return View(depts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _departmentService.Add(department);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            var dept = _departmentService.GetById(id);

            if (dept is null)
                return RedirectToNotFound();

            return View(dept);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToNotFound();

            return View(department);
        }

        [HttpPost]
        public IActionResult Update(int? id, Department department)
        {
            if (department.Id != id)
                return RedirectToNotFound();

            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var dept = _departmentService.GetById(id);

            if (dept is null)
                return RedirectToNotFound();

            _departmentService.Delete(dept);

            return RedirectToAction(nameof(Index));
        }

        private RedirectToActionResult RedirectToNotFound()
        {
            return RedirectToAction(
                nameof(HomeController.NotFoundPage),
                nameof(HomeController).Replace("Controller", "")
            );
        }
    }
}
