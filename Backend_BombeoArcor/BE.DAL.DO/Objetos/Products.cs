using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL.DO.Objetos
{
    public partial class Products
    {
        public Products()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public int? Category { get; set; }
        public bool? Active { get; set; }
    }
}
