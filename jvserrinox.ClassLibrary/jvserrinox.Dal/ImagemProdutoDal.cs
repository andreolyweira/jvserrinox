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
           AND ImagemProduto_CodProduto    = ?ImagemProduto_CodProduto;";

        const string cmdInsert = @"
        INSERT INTO jvserrinox.ImagemProduto
        (Caminho,ImagemProduto_CodTipoImagem,ImagemProduto_CodProduto)
        VALUES
        (?Caminho,?ImagemProduto_CodTipoImagem,?ImagemProduto_CodProduto); select LAST_INSERT_ID() as CodImagemProduto";

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

        public bool Inserir(ImagemProdutoInfo imagemProdutoInfo)
        {
            ExecutaComando exeComando = null;
            List<MySqlParameter> lParam = new List<MySqlParameter>();

            try
            {
                lParam.Add(new MySqlParameter("?Caminho", imagemProdutoInfo.Caminho));
                lParam.Add(new MySqlParameter("?ImagemProduto_CodTipoImagem", imagemProdutoInfo.ImagemProduto_CodTipoImagem));
                lParam.Add(new MySqlParameter("?ImagemProduto_CodProduto", imagemProdutoInfo.ImagemProduto_CodProduto));

                using (exeComando = new ExecutaComando(cmdInsert, lParam, ConexoesBanco.jvserrinox))
                {
                    var dr = exeComando.GetDataReader();
                    if (dr.Read())
                    {
                        imagemProdutoInfo.CodImagemProduto = int.Parse(dr["CodImagemProduto"].ToString());
                        return true;
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
            return false;
        }

    }
}
