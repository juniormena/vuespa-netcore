using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class ClientDbContext: DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Sold> Sold { get; set; }
        public DbSet<VentaProductos2> VentaProducto2 { get; set; }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) {

        }
    }
}
