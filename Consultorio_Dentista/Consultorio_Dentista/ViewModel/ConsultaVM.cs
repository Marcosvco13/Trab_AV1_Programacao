using Consultorio_Dentista.Model.Models;

namespace Consultorio_Dentista.ViewModel
{
    public class ConsultaVM
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public DateTime? datahora { get; set; }
        public string descricao { get; set; } 
        public string nomecliente { get; set; }

        public ConsultaVM()
        { 
        }

        public static List<ConsultaVM> ListarTodasConsultas()
        {
            var db = new CONSULTORIO_DENTISTAContext();
            return (from consulta in db.Consultas
                    join cliente in db.Cliente on consulta.IdCliente
                    equals cliente.Id
                    select new ConsultaVM
                    {
                        id = consulta.Id,
                        idcliente = consulta.IdCliente,
                        datahora = consulta.DataConsulta,
                        descricao = consulta.Descricao,
                        nomecliente = cliente.Nome,
                    }).ToList();
        }

        public static ConsultaVM Selecionar(int id)
        {
            var db = new CONSULTORIO_DENTISTAContext();
            return (from consulta in db.Consultas
                    join cliente in db.Cliente on consulta.IdCliente
                    equals cliente.Id
                    select new ConsultaVM
                    {
                        id = consulta.Id,
                        idcliente = consulta.IdCliente,
                        datahora = consulta.DataConsulta,
                        descricao = consulta.Descricao,
                        nomecliente = cliente.Nome,
                    }).FirstOrDefault();
        }
    }
}
