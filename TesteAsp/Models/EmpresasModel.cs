using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    [Table("Empresas")]
    public class EmpresasModel
    {
        [Key]
        [Display(Name="Cód. Empresa")]
        public int cod_empresa { get; set; }


        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        
    }
}