using Microsoft.AspNetCore.Mvc;

namespace MyTea.Controllers
{
    public class WBSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
