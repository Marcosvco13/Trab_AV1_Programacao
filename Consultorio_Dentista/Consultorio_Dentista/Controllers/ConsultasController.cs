using Consultorio_Dentista.Model.Services;
using Consultorio_Dentista.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Consultorio_Dentista.Controllers
{
    public class ConsultasController : Controller
    {
        private ServiceConsultas _ServiceConsultas;

        public ConsultasController()
        {
            _ServiceConsultas = new ServiceConsultas();    
        }
        public async Task<IActionResult> Index()
        {   
            var ListaConsultas = await _ServiceConsultas.oRepositoryConsultas.SelecionarTodosAsync();
            return View(ListaConsultas);

        }
        public void CarregaDadosViewBag()
        {
            ViewData["Id"] = new SelectList(_ServiceConsultas.oRepositoryConsultas.SelecionarTodos(), "ID_Cliente","Data_Consulta", "Hora_Consulta", "Descricao");

        }
        [HttpGet]
        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Consultas consultas)
        {
            CarregaDadosViewBag();
            if(ModelState.IsValid)
            {
                consultas = await _ServiceConsultas.oRepositoryConsultas.IncluirAsync(consultas); 
                return View(consultas);
            }
            else
            {
                return View(consultas);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tipoConsulta = await _ServiceConsultas.oRepositoryConsultas.SelecionarPkAsync(id);
            return View(tipoConsulta);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Consultas consulta)
        {
            if(ModelState.IsValid)
            {
                var tipoConsulta = await _ServiceConsultas.oRepositoryConsultas.AlterarAsync(consulta);
                return View(tipoConsulta);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceConsultas.oRepositoryConsultas.ExcluirAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var tipoConsulta = await _ServiceConsultas.oRepositoryConsultas.SelecionarPkAsync(id);
            return View(tipoConsulta);
        }

    }
}
