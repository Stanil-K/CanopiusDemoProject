using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
