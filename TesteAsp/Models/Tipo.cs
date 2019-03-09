using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    public class Tipo
    {
        [Key]
        public int TipoId { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        [Display(Name ="Tipo")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public int UMid { get; set; }
        public virtual UnidadeMedida UM { get; set; }

    }
}