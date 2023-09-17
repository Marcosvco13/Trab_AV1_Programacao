using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio_Dentista.Model.Repository;

namespace Consultorio_Dentista.Model.Services
{
    public class ServiceCliente
    {
        public RepositoryCliente oRepositoryCliente { get; set; }

        public ServiceCliente()
        {
            oRepositoryCliente = new RepositoryCliente();
        }
    }
}
