using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Model
{
    public class OrcamentoInfo : BaseInfo
    {
        public OrcamentoInfo() { }

        [AtributoCampo(true, "CodOrcamento", 4, false)]
        public int CodOrcamento { get; set; }

        [AtributoCampo("Nome", 100, true)]
        public string Nome { get; set; }

        [AtributoCampo("Telefone", 100, true)]
        public string Telefone { get; set; }

        [AtributoCampo("Email", 100, true)]
        public string Email { get; set; }

        [AtributoCampo("Cidade", 100, true)]
        public string Cidade { get; set; }

        [AtributoCampo("Uf", 100, true)]
        public string UF { get; set; }

        [AtributoCampo("Comentario", 100, true)]
        public string Comentario { get; set; }

        [AtributoCampo("Data", 100, true)]
        public DateTime Data { get; set; }
    }
}
