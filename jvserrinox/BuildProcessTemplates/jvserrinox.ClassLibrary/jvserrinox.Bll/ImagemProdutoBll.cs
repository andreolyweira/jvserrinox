using jvserrinox.Dal;
using jvserrinox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Bll
{
    public class ImagemProdutoBll
    {
        public ImagemProdutoInfo ListarPorCodProdutoCodTipoImagem(int codTipoImagem, int codProduto)
        {
            ImagemProdutoDal imagemProdutoDal = new ImagemProdutoDal();

            try
            {
                return imagemProdutoDal.ListarPorCodProdutoCodTipoImagem(codTipoImagem, codProduto);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                imagemProdutoDal = null;
            }
        }
    }
}
