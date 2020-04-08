using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace FinalProgamacion3.Models
{
    public class Context:DbContext
        
    {
        public Context()
           : base("Context")

        {
        }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Entradas> Entradas { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

    }
}