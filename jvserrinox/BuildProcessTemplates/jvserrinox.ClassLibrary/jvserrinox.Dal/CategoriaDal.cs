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
    public class CategoriaDal
    {
        const string cmdListarTodas = @"
        SELECT *
          FROM jvserrinox.Categoria";

        public List<CategoriaInfo> ListarTodas()
        {
            ExecutaComando exeComando = null;
            List<CategoriaInfo> lstCategoriaInfo = new List<CategoriaInfo>();
            MySqlDataReader dr = null;

            try
            {
                //lParam.Add(new MySqlParameter("@NOMEUSUARIO", nomeUsuario));
                //lParam.Add(new MySqlParameter("@SENHA", senha));


                using (exeComando = new ExecutaComando(cmdListarTodas, null, ConexoesBanco.jvserrinox))
                {
                    dr = exeComando.GetDataReader();
                    while (dr.Read())
                    {
                        NovaInstanciaClasse instancia = new NovaInstanciaClasse();
                        lstCategoriaInfo.Add(instancia.NovaInstancia<CategoriaInfo>(dr));
                    }
                }
                return lstCategoriaInfo;
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

    }
}
