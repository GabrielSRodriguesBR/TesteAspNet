using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    public class Estoque
    {
        [Key]
        public int estoqueId { get; set; }
        
        [Display(Name = "Quantidade")]
        public float quantidade { get; set; }

       
        public int produtoId { get; set; }
        public virtual Produto ProdEstoque { get; set; }
    }
}