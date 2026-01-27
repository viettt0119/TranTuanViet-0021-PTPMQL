
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;


namespace ProjectMVC.Controllers
{
public class StudentController : Controller
{
    [HttpGet]
    public ActionResult Create()
    {
        return View(new Student());
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
        if (student == null)
        {
            ViewBag.Alert = "Dữ liệu không hợp lệ.";
            return View(new Student());
        }

        if (string.IsNullOrWhiteSpace(student.StudentCode) || string.IsNullOrWhiteSpace(student.FullName))
        {
            ViewBag.Alert = "Vui lòng nhập đầy đủ Mã SV và Họ tên.";
            return View(student);
        }

        // Xử lý demo
        ViewBag.Alert = $"Đã nhận sinh viên: {student.StudentCode} - {student.FullName}";

        // Trả lại view cùng model để hiển thị lại input
        return View(student);
    }
}
}