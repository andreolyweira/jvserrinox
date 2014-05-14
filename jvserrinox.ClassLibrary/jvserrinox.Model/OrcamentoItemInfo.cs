using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Model
{
    public class OrcamentoItemInfo : BaseInfo
    {
        public OrcamentoItemInfo() { }

        [AtributoCampo(true, "CodOrcamentoItem", 4, false)]
        public int CodOrcamentoItem { get; set; }

        [AtributoCampo("Quantidade", 100, true)]
        public int Quantidade { get; set; }

        [AtributoCampo("OrcamentoItem_CodProduto", 100, true)]
        public int OrcamentoItem_CodProduto { get; set; }

        [AtributoCampo("OrcamentoItem_CodOrcamento", 100, true)]
        public int OrcamentoItem_CodOrcamento { get; set; }

        public string Guid { get; set; }

        public ProdutoInfo ProdutoInfo { get; set; }
    }
}
