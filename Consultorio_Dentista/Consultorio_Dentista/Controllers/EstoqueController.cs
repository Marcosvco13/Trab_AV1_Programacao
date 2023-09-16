using Consultorio_Dentista.Model.Services;
using Consultorio_Dentista.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Consultorio_Dentista.Controllers
{
    public class EstoqueController : Controller
    {
        private ServiceEstoque _ServiceEstoque;

        public EstoqueController()
        {
            _ServiceEstoque = new ServiceEstoque();
        }

        public async Task<IActionResult> Index()
        {
            var listaEstoque = await _ServiceEstoque.oRepositoryEstoque.SelecionarTodosAsync();
            return View(listaEstoque);
        }

        public void CarregaDadosViewBag()
        {
            ViewData["Id"] = new SelectList(_ServiceEstoque.oRepositoryEstoque.SelecionarTodos(), "NOME", "CPF", "TELEFONE");
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Estoque estoque)
        {
            CarregaDadosViewBag();
            if (ModelState.IsValid)
            {
                estoque = await _ServiceEstoque.oRepositoryEstoque.IncluirAsync(estoque);
                return View(estoque);
            }
            else
            {
                return View(estoque);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tipoEstoque = await _ServiceEstoque.oRepositoryEstoque.SelecionarPkAsync(id);
            return View(tipoEstoque);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Estoque estoque)
        {
            if(ModelState.IsValid)
            {
                var tipoEstoqueSalvo = await _ServiceEstoque.oRepositoryEstoque.AlterarAsync(estoque);
                return View(tipoEstoqueSalvo);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceEstoque.oRepositoryEstoque.ExcluirAsync(id);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var tipoEstoque = await _ServiceEstoque.oRepositoryEstoque.SelecionarPkAsync(id);
            return View(tipoEstoque);
        }
    }
}
