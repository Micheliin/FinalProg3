using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProgamacion3.Models
{
    [Table("Stock")]
    public class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDStock { get; set; }
        public int Cantidad { get; set; }
        public int IDProductos { get; set; }
        public Productos Productos { get; set; }
    }
}