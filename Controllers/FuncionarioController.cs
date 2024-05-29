using Microsoft.AspNetCore.Mvc;
using MyTea.Models;
using MyTea.Services;

namespace MyTea.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
