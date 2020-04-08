using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgamacion3.Models
{
    
    public class Facturacion
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public decimal TotalProducto { get; set; }
        public decimal TotalPagado { get; set; }
        public DateTime Fecha { get; set; }
        public List<Detalle_Factura> Detalle_Facturas { get; set; }
    }
}