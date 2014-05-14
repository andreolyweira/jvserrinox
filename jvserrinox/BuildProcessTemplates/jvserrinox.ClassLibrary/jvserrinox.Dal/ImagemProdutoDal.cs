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
    public class ImagemProdutoDal
    {
        const string cmdListarPorCodProdutoCodTipoImagem = @"
        SELECT *
          FROM jvserrinox.ImagemProduto
         WHERE ImagemProduto_CodTipoImagem = ?ImagemProduto_CodTipoImagem
           AND ImagemProduto_CodProduto    = ?ImagemProduto_CodProduto";

        public ImagemProdutoInfo ListarPorCodProdutoCodTipoImagem(int codTipoImagem, int codProduto)
        {
            ExecutaComando exeComando = null;
            List<MySqlParameter> lParam = new List<MySqlParameter>();
            MySqlDataReader dr = null;

            try
            {
                lParam.Add(new MySqlParameter("?ImagemProduto_CodTipoImagem", codTipoImagem));
                lParam.Add(new MySqlParameter("?ImagemProduto_CodProduto", codProduto));


                using (exeComando = new ExecutaComando(cmdListarPorCodProdutoCodTipoImagem, lParam, ConexoesBanco.jvserrinox))
                {
                    dr = exeComando.GetDataReader();
                    if (dr.Read())
                    {
                        NovaInstanciaClasse instancia = new NovaInstanciaClasse();
                        return instancia.NovaInstancia<ImagemProdutoInfo>(dr);
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
