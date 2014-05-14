using jvserrinox.Dal;
using jvserrinox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Bll
{
    public class TipoImagemBll
    {
        public TipoImagemInfo ListarPorCodigo(int codTipoImagem)
        {
            TipoImagemDal tipoImagemDal = new TipoImagemDal();

            try
            {
                return tipoImagemDal.ListarPorCodigo(codTipoImagem);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                tipoImagemDal = null;
            }
        }
    }
}
