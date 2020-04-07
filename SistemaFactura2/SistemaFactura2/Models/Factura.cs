using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaFactura2.Models
{
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDFactura { get; set; }

        public int IDCliente { get; set; }

        [ForeignKey("IDCliente")]
        public Clientes Cliente { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
        [Required]
        public DateTime FechaFactura { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}