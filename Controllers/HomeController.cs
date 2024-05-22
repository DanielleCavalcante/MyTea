using Microsoft.AspNetCore.Mvc;
using MyTea.Models;
using System.Diagnostics;

namespace MyTea.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Repository.TodasAsQuinzenas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Quinzenas registroQuinzena)
        {
            if(ModelState.IsValid)
            {
                Repository.Inserir(registroQuinzena);
                return View("Agradecimentos", registroQuinzena);
            }
            else
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
