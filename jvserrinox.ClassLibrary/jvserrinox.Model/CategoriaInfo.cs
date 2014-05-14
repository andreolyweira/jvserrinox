using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Model
{
    public class CategoriaInfo : BaseInfo
    {
        public CategoriaInfo()
        {

        }

        [AtributoCampo(true, "CodCategoria", 4, false)]
        public int CodCategoria { get; set; }

        [AtributoCampo("Nome", 100, true)]
        public string Nome { get; set; }

        [AtributoCampo("Ativo", 100, true)]
        public bool Ativo { get; set; }
    }
}
