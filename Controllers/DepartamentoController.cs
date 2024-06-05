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

        // 1ª tarefa assíncrona: Leitura e exibição dos dados, posteriormente, na View. 

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
                ModelState.AddModelError(string.Empty, "Não foi possível acessar os dados de Departamentos. Tente novamente.");
                return View(new List<Departamento>());
            }
        }

        // 2° CRUD: Seleção de registro
        public ViewResult GetDeptoUnico() => View();
        [HttpPost]
        // sobrecarga para selecionar o registo
        public async Task<IActionResult> GetDeptoUnico(int id)
        {
            // requisição para a seleção de registro
            var departamento = await _departamentoService.GetDeptoByIdAsync(id);

            // verificar o valor da var
            if (departamento == null)
                return NotFound();
            return View(departamento);
        }

        // CRUD READ - BUSCA POR REGISTRO UNICO
        public ViewResult BuscarDepto() => View();

        //sobrecarga do método
        [HttpPost]
        public async Task<IActionResult> BuscarDepto(int id)
        {
            // requisição com uso do service
            var departamento = await _departamentoService.GetDeptoByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // 3° CRUD: Inserção de dados - Create
        public ViewResult AddDepto() => View();
        [HttpPost]
        public async Task<IActionResult> AddDepto(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departamentoService.AddDeptoAsync(departamento);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao criar o registro de Departamento");
                }
            }
            return View(departamento);
        }

        // 3° CRUD: Inserção de dados - Create
        /*
         * Create + Validação se o nome do Departamento já existe
        public ViewResult AddDepto() => View();

        [HttpPost]
        public async Task<IActionResult> AddDepto(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                // Verificação se o nome do Departamento já existe
                if (await _departamentoService.DeptoNomeExisteAsync(departamento.Depto_Nome))
                {
                    ModelState.AddModelError("Depto_Nome", "Já existe um departamento com este nome.");
                }
                else
                {
                    try
                    {
                        await _departamentoService.AddDeptoAsync(departamento);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Erro ao criar o registro de Departamento");
                    }
                }
            }
            return View(departamento);
        } */

        // 4° CRUD: Update
        public async Task<IActionResult> UpdateDepto(int id)
        {
            // requisição para recuperar o registro
            var departamento = await _departamentoService.GetDeptoByIdAsync(id);

            // verificar se a requisição trouxe algum resultado
            if (departamento == null)
                return NotFound();
            return View(departamento);
        }

        // sobrecarga do método UpdateDepto
        [HttpPost]
        public async Task<IActionResult> UpdateDepto(int id, Departamento departamento)
        {
            if (id != departamento.Depto_Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _departamentoService.UpdateDeptoAsync(id, departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // 5° CRUD: Delete
        [HttpPost]
        public async Task<IActionResult> DeleteDepto(int id)
        {
            var departamento = await _departamentoService.GetDeptoByIdAsync(id);

            if (departamento == null)
                return NotFound();

            await _departamentoService.DeleteDeptoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}