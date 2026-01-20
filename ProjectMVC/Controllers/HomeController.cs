using Microsoft.AspNetCore.Mvc;

namespace ProjectMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}