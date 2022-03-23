using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL.DO.Objetos
{
    public partial class Instalador
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
