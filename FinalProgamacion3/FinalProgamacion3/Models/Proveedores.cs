using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProgamacion3.Models
{
    [Table("Proveedores")]
    public class Proveedores
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDProveedores { get; set; }
        [Required]
        public int RNC_cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*",
        ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        public string Email { get; set; }
    }
}