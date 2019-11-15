using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class VentaProductos2
    {
        public int Id { get; set; }
        public int SoldId { get; set; }
        [ForeignKey("SoldId")]
        public virtual Sold Sale { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
