using Microsoft.AspNetCore.Mvc;
using System;
public class HomeController : Controller
{
    public ActionResult About()
    {
        ViewBag.TitlePage = "Giới thiệu";
        ViewBag.Message = "Đây là dữ liệu gửi từ Controller sang View qua ViewBag.";
        ViewBag.Year = DateTime.Now.Year;
        return View();
    }
}
