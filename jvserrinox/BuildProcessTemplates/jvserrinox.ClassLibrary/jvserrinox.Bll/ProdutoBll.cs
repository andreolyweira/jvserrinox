using jvserrinox.Dal;
using jvserrinox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Bll
{
    public class ProdutoBll
    {
        public List<ProdutoInfo> ListarPorCategoria(int codCategoria)
        {
            ProdutoDal produtoDal = new ProdutoDal();

            try
            {
                return produtoDal.ListarPorCategoria(codCategoria);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                produtoDal = null;
            }
        }

        public ProdutoInfo ListarPorCodigoImgSmall(int codProduto)
        {
            ProdutoDal produtoDal = new ProdutoDal();

            try
            {
                return produtoDal.ListarPorCodigoImgSmall(codProduto);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                produtoDal = null;
            }
        }
    }
}
