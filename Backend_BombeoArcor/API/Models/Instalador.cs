using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Instalador
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
