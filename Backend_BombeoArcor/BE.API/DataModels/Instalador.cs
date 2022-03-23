using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Instalador
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
