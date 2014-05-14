using jvserrinox.Dal;
using jvserrinox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Bll
{
    public class OrcamentoBll
    {
        public bool Inserir(OrcamentoInfo orcamentoInfo)
        {
            OrcamentoDal orcamentoDal = new OrcamentoDal();

            try
            {
                return orcamentoDal.Inserir(orcamentoInfo);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                orcamentoDal = null;
            }
        }
    }
}
