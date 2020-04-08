using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaFactura2.Models
{
    public class Clientes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDClientes { get; set; }
        [Required]
        public int RNC { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        public string Email { get; set; }
        public int IDCategoria { get; set; }

        [ForeignKey("IDCategoria")]
        public Categorias Categoria { get; set; }
    }
}