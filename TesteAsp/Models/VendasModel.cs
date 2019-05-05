using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    [Table("Vendas")]
    public class VendasModel
    {
        [Key]
        [Display(Name ="Cód. Venda")]
        public int cod_venda { get; set; }

        [Display(Name = "Produto")]
        public int cod_produto { get; set; }

        [Display(Name = "Empresa")]
        public int cod_empresa { get; set; }

        [Display(Name = "Quantidade Vendida")]
        public double qtd { get; set; }

        [ForeignKey("cod_produto")]
        public virtual Produto FK_CodProduto { get; set; }

        [ForeignKey("cod_empresa")]
        public virtual EmpresasModel Empresas { get; set; }
    }
}