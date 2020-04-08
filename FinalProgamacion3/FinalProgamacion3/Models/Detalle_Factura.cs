using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FinalProgamacion3.Models
{
    public class Detalle_Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IDFacturacion { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public decimal Total { get; set; }
        public Productos Productos { get; set; }
    }
}