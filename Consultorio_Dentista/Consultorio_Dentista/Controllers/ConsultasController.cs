using Consultorio_Dentista.Model.Services;
using Consultorio_Dentista.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Consultorio_Dentista.Controllers
{
    public class ConsultasController : Controller
    {
        private ServiceConsultas _ServicioConsultas;

        public ConsultasController()
        {
            _ServicioConsultas = new ServiceConsultas();    
        }
        public async Task<IActionResult> Index()
        {   
            var ListaConsultas = await _ServicioConsultas.oRepositoryConsultas.SelecionarTodosAsync();
            return View(ListaConsultas);
        }

    }
}
