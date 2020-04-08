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
           : base("name-Context")

        {
        }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

    }
}