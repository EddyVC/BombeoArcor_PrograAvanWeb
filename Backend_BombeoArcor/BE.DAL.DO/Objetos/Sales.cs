using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.DAL.DO.Objetos
{
    public partial class Sales
    {
        public Sales()
        {

        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public decimal SaleTotal { get; set; }
    }
}
