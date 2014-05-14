using jvserrinox.Model;
using MySql.Data.MySqlClient;
using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Dal
{
    public class ProdutoDal
    {
        const string cmdListarPorCategoria = @"
        SELECT *
          FROM jvserrinox.Produto
         WHERE Produto_CodCategoria = ?Produto_CodCategoria";

        const string cmdListarPorCodigoImgSmall = @"
        SELECT pro.*, img.Caminho as CaminhoImagemTemp
          FROM jvserrinox.Produto pro
          LEFT JOIN jvserrinox.ImagemProduto img ON img.ImagemProduto_CodProduto = pro.CodProduto
         WHERE pro.CodProduto = ?CodProduto
           AND img.ImagemProduto_CodTipoImagem = ?ImagemProduto_CodTipoImagem";

        public List<ProdutoInfo> ListarPorCategoria(int codCategoria)
        {
            ExecutaComando exeComando = null;
            List<ProdutoInfo> lstProdutoInfo = new List<ProdutoInfo>();
            List<MySqlParameter> lParam = new List<MySqlParameter>();
            MySqlDataReader dr = null;

            try
            {
                lParam.Add(new MySqlParameter("?Produto_CodCategoria", codCategoria));


                using (exeComando = new ExecutaComando(cmdListarPorCategoria, lParam, ConexoesBanco.jvserrinox))
                {
                    dr = exeComando.GetDataReader();
                    while (dr.Read())
                    {
                        NovaInstanciaClasse instancia = new NovaInstanciaClasse();
                        lstProdutoInfo.Add(instancia.NovaInstancia<ProdutoInfo>(dr));
                    }
                }
                return lstProdutoInfo;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message, exc);
            }
            finally
            {
                exeComando = null;
            }
        }
        public ProdutoInfo ListarPorCodigoImgSmall(int codProduto)
        {
            ExecutaComando exeComando = null;
            List<MySqlParameter> lParam = new List<MySqlParameter>();
            MySqlDataReader dr = null;

            try
            {
                lParam.Add(new MySqlParameter("?CodProduto", codProduto));
                //---Cod 2 imagem 80 x 50
                lParam.Add(new MySqlParameter("?ImagemProduto_CodTipoImagem", 2));

                using (exeComando = new ExecutaComando(cmdListarPorCodigoImgSmall, lParam, ConexoesBanco.jvserrinox))
                {
                    dr = exeComando.GetDataReader();
                    if (dr.Read())
                    {
                        NovaInstanciaClasse instancia = new NovaInstanciaClasse();
                        return instancia.NovaInstancia<ProdutoInfo>(dr);
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message, exc);
            }
            finally
            {
                exeComando = null;
            }
            return null;
        }
    }
}
