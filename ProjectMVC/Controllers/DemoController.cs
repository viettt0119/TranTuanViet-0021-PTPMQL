using System;
using Microsoft.AspNetCore.Mvc;

public class DemoController : Controller
{
    public ActionResult Index()
    {
        ViewBag.TitlePage = "Demo ViewBag";
        ViewBag.Message = "Dữ liệu gửi từ Controller về View";
        ViewBag.Time = DateTime.Now;

        return View();
    }
}
