using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    public class Produto
    {
        [Key]
        [Display(Name = "Código")]
        public int id { get; set; }

        [Required(ErrorMessage ="Campo Descrição obrigatório!")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Tipo")]
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }

        public virtual ICollection<Estoque> estoqueProduto { get; set; }

        public virtual ICollection<VendasModel> vendasProduto{ get; set; }
    }
}