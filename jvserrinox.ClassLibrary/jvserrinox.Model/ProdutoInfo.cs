using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Model
{
    public class ProdutoInfo : BaseInfo
    {
        public ProdutoInfo()
        {

        }

        [AtributoCampo(true, "CodProduto", 4, false)]
        public int CodProduto { get; set; }

        [AtributoCampo("Nome", 100, true)]
        public string Nome { get; set; }

        [AtributoCampo("Descricao", 100, true)]
        public string Descricao { get; set; }

        [AtributoCampo("Ativo", 100, true)]
        public bool Ativo { get; set; }

        [AtributoCampo("Produto_CodCategoria", 100, true)]
        public int Produto_CodCategoria { get; set; }

        [AtributoCampo("CaminhoImagemTemp", 100, true)]
        public string CaminhoImagemTemp { get; set; }
    }
}
