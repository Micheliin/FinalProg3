using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProgamacion3.Models
{
    [Table("Ventas")]
    public class Ventas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDVentas { get; set; }

        public int? Id { get; set; }

        public int? IDClientes { get; set; }

        public int Cantidad { get; set; }

        public DateTime? Fecha { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
