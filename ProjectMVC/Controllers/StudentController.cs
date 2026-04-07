using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectMVC.Data;
using ProjectMVC.Models.Entities;
using ProjectMVC.Models.ViewModels;

namespace ProjectMVC.Controllers
{
    public class StudentController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IActionResult> Index(string? keyword)
        {
            var query = _context.Students
                .Include(student => student.Faculty)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(student =>
                    student.StudentCode.Contains(keyword) ||
                    student.FullName.Contains(keyword) ||
                    student.Email.Contains(keyword) ||
                    student.Faculty!.FacultyName.Contains(keyword));
            }

            ViewBag.Keyword = keyword;
            var listStudents = await query
                .OrderBy(student => student.StudentCode)
                .Select(student => new StudentFacultyViewModel
                {
                    StudentCode = student.StudentCode,
                    FullName = student.FullName,
                    FacultyName = student.Faculty!.FacultyName
                })
                .ToListAsync();

            return View(listStudents);
        }

        public async Task<IActionResult> Create()
        {
            await LoadFacultiesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (!ModelState.IsValid)
            {
                await LoadFacultiesAsync(std.FacultyID);
                return View(std);
            }

            var facultyExists = await _context.Faculties.AnyAsync(faculty => faculty.FacultyID == std.FacultyID);
            if (!facultyExists)
            {
                ModelState.AddModelError(nameof(Student.FacultyID), "Khoa khong ton tai.");
                await LoadFacultiesAsync(std.FacultyID);
                return View(std);
            }

            var studentExists = await _context.Students.AnyAsync(student => student.StudentCode == std.StudentCode);
            if (studentExists)
            {
                ModelState.AddModelError(nameof(Student.StudentCode), "Ma sinh vien da ton tai.");
                await LoadFacultiesAsync(std.FacultyID);
                return View(std);
            }

            _context.Students.Add(std);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }

            await LoadFacultiesAsync(std.FacultyID);
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Student std)
        {
            if (id != std.StudentCode)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await LoadFacultiesAsync(std.FacultyID);
                return View(std);
            }

            var facultyExists = await _context.Faculties.AnyAsync(faculty => faculty.FacultyID == std.FacultyID);
            if (!facultyExists)
            {
                ModelState.AddModelError(nameof(Student.FacultyID), "Khoa khong ton tai.");
                await LoadFacultiesAsync(std.FacultyID);
                return View(std);
            }

            var studentExists = await _context.Students.AnyAsync(student => student.StudentCode == id);
            if (!studentExists)
            {
                return NotFound();
            }

            _context.Update(std);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var std = await _context.Students
                .Include(student => student.Faculty)
                .AsNoTracking()
                .FirstOrDefaultAsync(student => student.StudentCode == id);
            if (std == null)
            {
                return NotFound();
            }

            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadFacultiesAsync(int selectedFacultyId = 0)
        {
            var faculties = await _context.Faculties
                .OrderBy(faculty => faculty.FacultyName)
                .ToListAsync();

            ViewBag.Faculties = new SelectList(faculties, nameof(Faculty.FacultyID), nameof(Faculty.FacultyName), selectedFacultyId);
        }
    }
}
