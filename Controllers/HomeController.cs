using Microsoft.AspNetCore.Mvc;
using MyTea.Models;
using MyTea.Services;
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

        /*public IActionResult Index()
        {
           
            return View();

        }*/

        private LancamentoHorasService _lancamentoService;

        public HomeController(LancamentoHorasService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        //inicio========================================================================================================================
        public async Task<IActionResult> Index()
        {
            var viewModel = new ViewModelListar
            {
                Funcionario = await _lancamentoService.Funcionario.()
            };

            return View(viewModel);
        }
        //fim==========================================================================================================================

        /*
        public IActionResult Index()
        {
            var feriado = new Horas
            {
                Feriado = true, // condicional para criar uma linha na tabela quando existe feriado no mês
                LinhaAdicionalTabela = true, // condicional para criar uma linha na tabela quando as primeiras cinco linhas já foram usadas
                               
            };

            return View(feriado);
            
        }*/

        /*
        [HttpPost]
        public IActionResult Index(Horas registroHoras)
        {

            if (ModelState.IsValid)
            {
                Repository.Inserir(registroHoras);
                return View("Index", registroHoras);
            }
            else
            {
                return View();
            }
        }

               
        [HttpPost]
        public ActionResult CalcularHoras(int valor1, int valor2)
        {
            var validacaoHoras = new Horas();

            int resultado = valor1 + valor2;            

            if (valor1 < 8)
            {
                validacaoHoras.MensagemErroHorasDia = true;
            } else if (resultado < 88)
                {
                validacaoHoras.MensagemErroHorasQuinz = true;
                }
                else
            {
                validacaoHoras.MensagemErroHorasQuinz = false;
                validacaoHoras.MensagemErroHorasDia = false;
            }
            return View("Index", validacaoHoras);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
