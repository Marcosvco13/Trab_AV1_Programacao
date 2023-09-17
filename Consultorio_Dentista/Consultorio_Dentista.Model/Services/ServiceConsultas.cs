using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio_Dentista.Model.Repository;

namespace Consultorio_Dentista.Model.Services
{
    public class ServiceConsultas
    {
        public RepositoryConsultas oRepositoryConsultas { get; set; }

        public RepositoryCliente oRepositoryCliente { get; set; }
        public ServiceConsultas()
        {
            oRepositoryConsultas = new RepositoryConsultas();

            oRepositoryCliente = new RepositoryCliente();
        }
    }
}
