using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SistemaFactura2.Models
{
    public class MantenimientoContext:DbContext
    {
        public MantenimientoContext() : base("FinalSistemaF")
        {

        }

        public DbSet<Productos> Producto { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Proveedores> Proveedor { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<EntradaMercancia> EntradaMercancias { get; set; }
    }
}