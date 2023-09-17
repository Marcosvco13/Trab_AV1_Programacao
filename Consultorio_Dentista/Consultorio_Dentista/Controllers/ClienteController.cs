using Consultorio_Dentista.Model.Models;
using Consultorio_Dentista.Model.Services;
using Consultorio_Dentista.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Dentista.Controllers
{
    public class ClienteController : Controller
    {
        private ServiceCliente _ServiceCliente;
        public ClienteController()
        {
            _ServiceCliente = new ServiceCliente();
        }

        public IActionResult Index()
        {
            var listaClientesVM = ClienteVM.ListarTodosClientes();
            return View(listaClientesVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteVM clienteVM)
        {
            var cliente = new Cliente();
            cliente.Nome = clienteVM.Nome;
            cliente.Cpf = clienteVM.Cpf;
            cliente.DataNascimento = (DateTime)clienteVM.DataNasc;
            cliente.NomeResp = clienteVM.NomeResp;
            cliente.Telefone = clienteVM.Tel;
            cliente.Email = clienteVM.Email;
            cliente.Cep = clienteVM.Cep;
            cliente.Bairro = clienteVM.Bairro;
            cliente.Logradouro = clienteVM.Logra;
            cliente.Numero = clienteVM.Num;
            cliente.Cidade = clienteVM.Cidade;
            cliente.Estado = clienteVM.Estado;

            await _ServiceCliente.oRepositoryCliente.IncluirAsync(cliente);

            return View(clienteVM); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _ServiceCliente.oRepositoryCliente.SelecionarPkAsync(id);
            return View(cliente);
        }

        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente = await _ServiceCliente.oRepositoryCliente.AlterarAsync(cliente);
                return View(cliente);
            }
            return View(cliente);
        }

        public async Task<IActionResult> Delete(ClienteVM clienteVM)
        {
            var cliente = await _ServiceCliente.oRepositoryCliente.SelecionarPkAsync(clienteVM.Id);
            await _ServiceCliente.oRepositoryCliente.ExcluirAsync(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteVM = ClienteVM.SelecionarCliente(id);
            return View(clienteVM);
        }
    }
}
