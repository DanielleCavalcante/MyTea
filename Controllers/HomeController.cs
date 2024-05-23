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

        /* 
         
           public IActionResult Index()
        {
            int quantidade = 5; // Exemplo de quantidade
            decimal precoUnitario = 20.0m; // Exemplo de preço unitário
            decimal desconto = 0.1m; // 10% de desconto
            decimal precoTotal;

            if (quantidade > 10)
            {
                precoTotal = (quantidade * precoUnitario) * (1 - desconto);
            }
            else
            {
                precoTotal = quantidade * precoUnitario;
            }

            ViewBag.PrecoTotal = precoTotal;

            return View();
        }
         
         */

        public IActionResult Index()
        {
            var feriado = new Horas
            {
                Feriado = true, // condicional para criar uma linha na tabela quando existe feriado no mês
                LinhaAdicionalTabela = true, // condicional para criar uma linha na tabela quando as primeiras cinco linhas já foram usadas
                               
            };

            return View(feriado);
            
        }


            [HttpPost]
        public IActionResult Index(Horas registroHoras)
        {
            if (ModelState.IsValid)
            {
                Repository.Inserir(registroHoras);
                return View("_TestePartialView", registroHoras);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
