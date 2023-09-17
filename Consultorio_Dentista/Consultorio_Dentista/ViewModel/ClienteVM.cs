using System.ComponentModel;
using System.Drawing;
using Consultorio_Dentista.Model.Models;

namespace Consultorio_Dentista.ViewModel
{
    public class ClienteVM
    {
        #region DadosCliente
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime? DataNasc {  get; set; }
        [DisplayName("Nome do Responsável")]
        public string NomeResp {  get; set; }
        [DisplayName("Telefone")]
        public string Tel { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Logradouro")]
        public string Logra { get; set; }
        [DisplayName("Número")]
        public string Num { get; set; }
        [DisplayName("CEP")]
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade {  get; set; }
        public string Estado { get; set; }
        #endregion

        public ClienteVM() 
        { 
        }

        public static ClienteVM SelecionarCliente(int id)
        {
            var db = new CONSULTORIO_DENTISTAContext();
            var cliente = db.Cliente.Find(id);
            var clienteVM = new ClienteVM();
            clienteVM.Id = cliente.Id;
            clienteVM.Nome = cliente.Nome;
            clienteVM.Cpf = cliente.Cpf;
            clienteVM.NomeResp = cliente.NomeResp;
            clienteVM.DataNasc = cliente.DataNascimento;
            clienteVM.Tel = cliente.Telefone;
            clienteVM.Email = cliente.Email;
            clienteVM.Logra = cliente.Logradouro;
            clienteVM.Num = cliente.Numero;
            clienteVM.Cep = cliente.Cep;
            clienteVM.Bairro = cliente.Bairro;
            clienteVM.Cidade = cliente.Cidade;
            clienteVM.Estado = cliente.Estado;
            return clienteVM;
        }

        public static List<ClienteVM> ListarTodosClientes()
        {
            var db = new CONSULTORIO_DENTISTAContext();
            return (from cliente in db.Cliente
                    select new ClienteVM
                    {
                        Nome = cliente.Nome,
                        Id = cliente.Id,
                        Cpf = cliente.Cpf.Length < 14 ? cliente.Cpf : "",
                        DataNasc = cliente.DataNascimento,
                        NomeResp = cliente.NomeResp,
                        Tel = cliente.Telefone,
                        Email = cliente.Email,
                        Logra = cliente.Logradouro,
                        Num = cliente.Numero,
                        Cep = cliente.Cep,
                        Bairro = cliente.Bairro,
                        Cidade = cliente.Cidade,
                        Estado = cliente.Estado
                     }).ToList();
        }
    }
}
