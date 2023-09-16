using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Dentista.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
