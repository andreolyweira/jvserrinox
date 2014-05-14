using jvserrinox.Dal;
using jvserrinox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Bll
{
    public class OrcamentoItemBll
    {
        public bool Inserir(OrcamentoItemInfo orcamentoItemInfo)
        {
            OrcamentoItemDal orcamentoItemDal = new OrcamentoItemDal();

            try
            {
                return orcamentoItemDal.Inserir(orcamentoItemInfo);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                orcamentoItemDal = null;
            }
        }
    }
}
