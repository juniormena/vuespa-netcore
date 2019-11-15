using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class VentaProducto
    {
        public Sold Sold { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
