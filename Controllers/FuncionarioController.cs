    using Microsoft.AspNetCore.Mvc;
    using MyTea.Models;
    using MyTea.Services;

    namespace MyTea.Controllers
    {
        public class FuncionarioController : Controller
        {
            // definir o elemento referencial para a DI(Injeção de Dependência) para as operações do Controller. 

            private FuncionarioService _funcionarioService;
            private DepartamentoService _departamentoService;
            private NivelAcessoService _nivelAcessoService;

            // definir o construtor
            public FuncionarioController(FuncionarioService funcionarioService, DepartamentoService departamentoService, NivelAcessoService nivelAcessoService)
            {
                _funcionarioService = funcionarioService;
                _departamentoService = departamentoService;
                _nivelAcessoService = nivelAcessoService;
            }

            // 1ª TAREFA CRUD: Leitura e exibição dos dados, posteriormente, na view. 
            public async Task<IActionResult> Index()
            {
                try
                {
                    var listarFunc = await _funcionarioService.GetFuncAsync();
                    return View(listarFunc);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível acessar os dados dos funcionários. Tente novamente.");
                    return View(new List<Funcionario>());
                }
            }

            // 2° TAREFA CRUD: Seleção Mais Detalhes de Registro
            public ViewResult VerMaisFunc() => View();

            [HttpPost]
            public async Task<IActionResult> VerMaisFunc(int id)
            {
                // requisição com uso do service
                var funcionario = await _funcionarioService.GetFuncByIdAsync(id);
                if (funcionario == null)
                {
                    return NotFound();
                }
                return View(funcionario);
            }

            // 2 tarefa parte 2 - buscar por unico registro
            public ViewResult BuscarFunc() => View();

            //sobrecarga do método
            [HttpPost]
            public async Task<IActionResult> BuscarFunc(int id)
            {
                // requisição com uso do service
                var funcionario = await _funcionarioService.GetFuncByIdAsync(id);
                if (funcionario == null)
                {
                    return NotFound();
                }

                return View(funcionario);
            }

            // 3° tarefa assincrona CRUD: Inserção - Create
            public ViewResult CriarFunc() => View();

            // sobrecarga do método/action
            [HttpPost]
            public async Task<IActionResult> AddFunc(Funcionario funcionario)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await _funcionarioService.AddFuncAsync(funcionario);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao criar o registro de curso.");
                    }
                }
                return View(funcionario);
            }

        /*//METODO DE LISTAGEM DE DEPARTAMENTOS - DROPDOWN
        public async Task<IActionResult> ListarDepartamentos()
        {
            try
            {
                var listarDepto = new ViewModelListar(); //ver se pode apagar
                listarDepto.Departamentos = await _departamentoService.GetDeptoAsync();

                return View(listarDepto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível acessar os dados dos funcionários. Tente novamente.");
                return View(new List<Funcionario>());
            }
        }*/


            // 4° tarefa assincrona CRUD: Update
            public async Task<IActionResult> EditarFunc(int id)
            {
                // estabelecer a requisição para recuperar o registro
                var funcionario = await _funcionarioService.GetFuncByIdAsync(id);

                // verificar se a requisição trouxe algum resultado
                if (funcionario == null)
                {
                    return NotFound();
                }

                return View(funcionario);
            }

            // sobrecarga do método/action
            [HttpPost]
            public async Task<IActionResult> EditarFunc(int id, Funcionario funcionario)
            {
                if (id != funcionario.Func_Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    await _funcionarioService.UpdateFuncAsync(id, funcionario);
                    return RedirectToAction(nameof(Index));
                }
                return View(funcionario);
            }

            // 5° tarefa assincrona CRUD: Excluir - Delete
            [HttpPost]
            public async Task<IActionResult> ExcluirFunc(int id)
            {
                // criar a requisição de seleção do registro para ser excluido
                var funcionario = await _funcionarioService.GetFuncByIdAsync(id);
                if (funcionario == null)
                {
                    return NotFound();
                }
                await _funcionarioService.DeleteFuncAsync(id);

                return RedirectToAction(nameof(Index));
            }
        }
    }
