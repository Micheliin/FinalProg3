﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FinalProgamacion3.Models
{
    [Table("Facturacion")]
    public class Facturacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalProducto { get; set; }
        public decimal TotalPagado { get; set; }
        public DateTime Fecha { get; set; }
        public List<Detalle_Factura> Detalle_Facturas { get; set; }
    }
}