using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio_Dentista.Model.Repository;

namespace Consultorio_Dentista.Model.Services
{
    public class ServiceEstoque
    {
        public RepositoryEstoque oRepositoryEstoque {  get; set; }

        public ServiceEstoque()
        {
            oRepositoryEstoque = new RepositoryEstoque();
        }
    }
}
