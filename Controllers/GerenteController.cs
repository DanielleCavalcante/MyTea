using Microsoft.AspNetCore.Mvc;

namespace MyTea.Controllers
{
    public class GerenteController : Controller
    {
        public IActionResult Gerente()
        {
            return View();
        }
    }
}
