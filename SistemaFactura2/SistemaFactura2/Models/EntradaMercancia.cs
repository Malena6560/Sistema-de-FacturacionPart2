using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaFactura2.Models
{
    public class EntradaMercancia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDEntrada { get; set; }
        public int IDProducto { get; set; }

        [ForeignKey("IDProducto")]
        public Productos Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }
        public int IDProveedor { get; set; }

        [ForeignKey("IDProveedor")]
        public Proveedores Proveedor { get; set; }

        [Required]
        public DateTime FechaEntrada { get; set; }
    }
}