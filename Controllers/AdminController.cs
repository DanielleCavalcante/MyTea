using Microsoft.AspNetCore.Mvc;

namespace MyTea.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
      
    }
}
