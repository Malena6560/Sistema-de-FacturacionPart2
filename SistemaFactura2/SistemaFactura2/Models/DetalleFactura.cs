using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaFactura2.Models
{
    public class DetalleFactura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDDetalle { get; set; }

        public int IDFactura { get; set; }

        [ForeignKey("IDFactura")]
        public Factura Factura { get; set; }

        public int IDProducto { get; set; }

        [ForeignKey("IDProducto")]
        public Productos Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
    }
}