﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio_Dentista.Model.Models;

namespace Consultorio_Dentista.Model.Repository
{
    public class RepositoryConsultas : RepositoryBase<Consultas>
    {
        public RepositoryConsultas(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
