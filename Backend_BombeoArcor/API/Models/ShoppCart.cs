using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class ShoppCart
    {
        public string IdUser { get; set; }
        public int? IdProduct { get; set; }
        public int Quantity { get; set; }

        public virtual Products IdProductNavigation { get; set; }
        public virtual AspNetUsers IdUserNavigation { get; set; }
    }
}
