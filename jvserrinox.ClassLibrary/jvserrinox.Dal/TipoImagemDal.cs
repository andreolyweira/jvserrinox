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
    public class TipoImagemDal
    {
        const string cmdListarPorCodigo = @"
        SELECT *
          FROM jvserrinox.TipoImagem
         WHERE CodTipoImagem = ?CodTipoImagem";

        public TipoImagemInfo ListarPorCodigo(int codTipoImagem)
        {
            ExecutaComando exeComando = null;
            List<MySqlParameter> lParam = new List<MySqlParameter>();
            MySqlDataReader dr = null;

            try
            {
                lParam.Add(new MySqlParameter("?CodTipoImagem", codTipoImagem));


                using (exeComando = new ExecutaComando(cmdListarPorCodigo, lParam, ConexoesBanco.jvserrinox))
                {
                    dr = exeComando.GetDataReader();
                    if (dr.Read())
                    {
                        NovaInstanciaClasse instancia = new NovaInstanciaClasse();
                        return instancia.NovaInstancia<TipoImagemInfo>(dr);
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
