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
        public ActionResult CalcularHorasDia(int valor1, int valor2)
        {
            var modelo = new Horas();

            int resultado = valor1 + valor2;            

            if (valor1 < 8)
            {
                modelo.MensagemErroHorasDia = true;
            } else if (resultado < 88)
                {
                    modelo.DeveMostrarDiv = true;
                }
                else
            {
                modelo.DeveMostrarDiv = false;
                modelo.MensagemErroHorasDia = false;
            }
            return View("Index", modelo);
        }

        /*
        public ActionResult CalcularHorasDia(string valor1)
        {
            var modelo = new Horas();
            double val1;

            if (double.TryParse(valor1, out val1))
            {
                
                modelo.MensagemErroHorasDia = false;
            }
            else { 
               
                modelo.MensagemErroHorasDia = true;
            }
            return View("Index", modelo);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
