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

        [HttpPost]
        public ActionResult Calcular(string valor1, string valor2)
        {
            var modelo = new Horas();
            // Tente converter os valores para double
            double val1, val2;
            if (double.TryParse(valor1, out val1) && double.TryParse(valor2, out val2))
            {
                // Realize o cálculo
                double resultado = val1 + val2;
                // Defina a condição com base no resultado do cálculo
                modelo.DeveMostrarDiv = resultado < 88;
            }
            else
            {
                // Se a conversão falhar, defina a condição como false
                modelo.DeveMostrarDiv = false;
            }
            return View("Index", modelo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
