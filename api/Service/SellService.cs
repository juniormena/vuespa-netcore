using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Persistence;

namespace Service
{
    public interface ISellService {
        bool Add(VentaProducto ventaProducto);
            }
    public class SellService:ISellService
    {
        private readonly ClientDbContext _clientDbContext;

        public SellService(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
            
        }
        public bool Add(VentaProducto ventaProducto) {
            try
            {
                _clientDbContext.Add(ventaProducto);
                _clientDbContext.SaveChanges();
                var maxID = _clientDbContext.Sold.Max(x => x.SoldId);
                VentaProductos2 vp;
                foreach (var p in ventaProducto.Products) {
                    vp = new VentaProductos2();
                    vp.SoldId = maxID;
                    vp.ProductId = p.ProductId;
                    _clientDbContext.VentaProducto2.Add(vp);
                    _clientDbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
