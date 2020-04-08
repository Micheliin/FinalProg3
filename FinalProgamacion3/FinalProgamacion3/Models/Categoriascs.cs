using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FinalProgamacion3.Models
{
    [Table("Categorias")]
    public class Categoriascs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? IdCategoriascs { get; set; }
        [Required]
        
        public string Descripcion { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}