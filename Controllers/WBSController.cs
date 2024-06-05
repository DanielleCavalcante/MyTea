using Microsoft.AspNetCore.Mvc;
using MyTea.Models;
using MyTea.Services;

namespace MyTea.Controllers
{
    public class WBSController : Controller
    {
        private WBSService _wbsService;

        public WBSController(WBSService wbsService)
        {
            _wbsService = wbsService;
        }

        /* === READ ===*/
        // Todos os registros
        public async Task<IActionResult> Index()
        {
            try
            {
                var listaWBS = await _wbsService.GetWBSAsync();
                return View(listaWBS);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível acessar os dados de WBS. Tente novamente.");
                return View(new List<WBS>());
            }
        }

        // Somente um registro pelo id
        public ViewResult GetWBSUnico() => View();

        [HttpPost]
        public async Task<IActionResult> GetWBSUnico(int id)
        {
            var wbs = await _wbsService.GetWBSByIdAsync(id);

            if (wbs == null)
            {
                return NotFound();
            }
            return View(wbs);
        }

        /* === CREATE === */

        public ViewResult AddWBS() => View();

        [HttpPost]
        public async Task<IActionResult> AddWBS(WBS wbs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _wbsService.AddWBSAsync(wbs);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao criar o registro de WBS.");
                }
            }
            return View(wbs);
        }

        /* === UPDATE === */

        public async Task<IActionResult> UpdateWBS(int id)
        {
            var wbs = await _wbsService.GetWBSByIdAsync(id);

            if (wbs == null)
            {
                return NotFound();
            }

            return View(wbs);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWBS(int id, WBS wbs)
        {
            if (id != wbs.WBS_Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _wbsService.UpdateWBSAsync(id, wbs);
                return RedirectToAction(nameof(Index));
            }

            return View(wbs);
        }

        /* === DELETE === */

        [HttpPost]
        public async Task<IActionResult> DeleteWBS(int id)
        {
            var wbs = await _wbsService.GetWBSByIdAsync(id);

            if (wbs == null)
            {
                return NotFound();
            }

            // caso contrário, a exclusão será executada
            await _wbsService.DeleteWBSAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
