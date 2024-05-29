using Microsoft.AspNetCore.Mvc;
using MyTea.Models;
using MyTea.Services;

namespace MyTea.Controllers
{
    public class DepartamentoController : Controller
    {
        // definir o elemento referencial para a DI(Injeção de Dependência)
        // para as operações do Controller. 

        private DepartamentoService _departamentoService;

        // definir o construtor
        public DepartamentoController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // 1ª tarefa assíncrona: Leitura e exibição dos dados, posteriormente,
        // na view. 

        public async Task<IActionResult> Index()
        {
            try
            {
                var listarDepto = await
                    _departamentoService.GetDeptoAsync();
                return View(listarDepto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível acessar os" +
                    "dados de estudantes. Tente novamente.");
                return View(new List<Departamento>());
            }
        }
    }
}
