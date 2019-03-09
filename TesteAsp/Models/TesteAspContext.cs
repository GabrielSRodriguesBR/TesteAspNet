using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TesteAsp.Models
{
    public class TesteAspContext : DbContext 
    {
        public TesteAspContext() : base("DefaultConection")
        {

        }

        public System.Data.Entity.DbSet<TesteAsp.Models.Tipo> Tipoes { get; set; }

        public System.Data.Entity.DbSet<TesteAsp.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<TesteAsp.Models.Estoque> Estoques { get; set; }

        public System.Data.Entity.DbSet<TesteAsp.Models.UnidadeMedida> UnidadeMedidas { get; set; }
    }
}