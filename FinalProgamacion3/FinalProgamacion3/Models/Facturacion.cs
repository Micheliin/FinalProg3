using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProgamacion3.Models
{
    [Table("Facturacion")]
    public class Facturacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDFacturacion { get; set; }

        public int? IDClientes { get; set; }

        public decimal? Descuento { get; set; }

        public decimal Monto { get; set; }

        public DateTime? Fecha { get; set; }

        public virtual Cliente Cliente { get; set; }

        public decimal descuento(decimal Cantidad, string Categoria)
        {
            if (Categoria.ToLower().Equals("premium"))
                Cantidad -= (Cantidad * 0.25m);

            return Cantidad;
        }

        public decimal itbis(decimal Cantidad)
        {
            Cantidad += (Cantidad * 0.18m);

            return Cantidad;
        }

        public int conteo(List<Facturacion> list)
        {
            return list.Count;
        }
        public decimal sumatoria(List<Facturacion> list)
        {
            return list.Sum(f => f.Monto);
        }

        public decimal promedio(List<Facturacion> list)
        {
            return list.Sum(f => f.Monto) / list.Count;
        }
        public decimal valorMinimo(List<Facturacion> list)
        {
            return list.Min(f => f.Monto);
        }
        public decimal valorMaximo(List<Facturacion> list)
        {
            return list.Max(f => f.Monto);
        }
    }
}
