﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Consultorio_Dentista.Model.Models;

public partial class Consultas
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateTime DataConsulta { get; set; }

    public DateTime HoraConsulta { get; set; }

    public string Descricao { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; }
}