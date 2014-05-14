using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Model
{
    public class TipoImagemInfo : BaseInfo
    {
        public TipoImagemInfo()
        { }

        [AtributoCampo(true, "CodTipoImagem", 4, false)]
        public int CodTipoImagem { get; set; }

        [AtributoCampo("Descricao", 100, true)]
        public string Descricao { get; set; }

        [AtributoCampo("Tamanho", 100, true)]
        public string Tamanho { get; set; }
    }
}
