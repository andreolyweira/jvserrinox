using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Model
{
    public class ImagemProdutoInfo : BaseInfo
    {
        [AtributoCampo(true, "CodImagemProduto", 4, false)]
        public int CodImagemProduto { get; set; }

        [AtributoCampo("Caminho", 100, true)]
        public string Caminho { get; set; }

        [AtributoCampo("ImagemProduto_CodTipoImagem", 100, true)]
        public int ImagemProduto_CodTipoImagem { get; set; }

        [AtributoCampo("ImagemProduto_CodProduto", 100, true)]
        public int ImagemProduto_CodProduto { get; set; }
    }
}
