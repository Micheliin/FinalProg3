using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProgamacion3.Models
{
    [Table("Entradas")]
    public class Entradas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDEntradas { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int IDProductos { get; set; }
        public int IDProveedores { get; set; }

        public Productos Productos { get; set; }
        public Proveedores Proveedores { get; set; }
       
    }
}