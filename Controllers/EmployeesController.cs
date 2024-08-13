using Microsoft.AspNetCore.Mvc;
using Staff_Management.Entities;
using System.ComponentModel.DataAnnotations;

using Staff_Management.ViewModels;
namespace Staff_Management.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // Hiển thị form thêm nhân viên
        public IActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel
            {
                DepartmentId = departmentId
            };
            return View(model);
        }

        // Xử lý thêm nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employees
                {
                    Name = model.Name,
                    Email = model.Email,
                    DepartmentId = model.DepartmentId
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Departments");
            }

            return View(model);
        }

       
    }
}
