using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staff_Management.Entities;

namespace Staff_Management.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DataContext _context;

        public DepartmentsController(DataContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách phòng ban
        public IActionResult Index()
        {
            var departments = _context.Departments
                              .Include(d => d.Employees) // Bao gồm danh sách nhân viên
                              .ToList();
            return View(departments);
        }

        // Hiển thị form thêm mới phòng ban
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm mới phòng ban
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departments department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }



        // Hiển thị form sửa phòng ban
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // Xử lý cập nhật phòng ban
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Departments department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Xác nhận xóa phòng ban
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // Xử lý xóa phòng ban
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
