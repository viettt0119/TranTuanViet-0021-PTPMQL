using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMVC.Controllers
{
    [Route("[controller]")]
    public class GreetingController : Controller
    {
        [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            ViewBag.Alert = "Vui lòng nhập họ tên.";
        }
        else
        {
            ViewBag.Alert = "Xin chào " + fullName;
        }

        // Giữ lại dữ liệu đã nhập để hiện lại trên ô input
        ViewBag.FullName = fullName;

        return View();
    }
    }
}