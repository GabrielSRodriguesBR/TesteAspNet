using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    public class UnidadeMedida
    {
        [Key]
        public int UMid { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório")]
        public string unidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string descricao { get; set; }

        public virtual ICollection<Tipo> UMtipo { get; set; }

    }
}