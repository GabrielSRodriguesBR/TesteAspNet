using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAsp.ViewModel
{
    public class RelatorioViewModel
    {
        public int ID { get; set; }
        public string TipoId { get; set; }
        public string ProdDescricao { get; set; }
        public string TipoDescricao { get; set; }
        public float Quantidade { get; set; }
        public string Unidade { get; set; }
    }

    public class SearchViewModel
    {
        public string cod_tipo { get; set; }
        public string unidade { get; set; }
    }

}