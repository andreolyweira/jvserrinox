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
    public class OrcamentoDal
    {
        const string cmdInsert = @"
        INSERT INTO jvserrinox.Orcamento
        (Nome,Telefone,Email,Cidade,Uf,Comentario,Data)
        VALUES
        (?Nome,?Telefone,?Email,?Cidade,?Uf,?Comentario,?Data); select LAST_INSERT_ID() as CodOrcamento";

        public bool Inserir(OrcamentoInfo orcamentoInfo)
        {
            ExecutaComando exeComando = null;
            List<MySqlParameter> lParam = new List<MySqlParameter>();

            try
            {
                lParam.Add(new MySqlParameter("?Nome", orcamentoInfo.Nome));
                lParam.Add(new MySqlParameter("?Telefone", orcamentoInfo.Telefone));
                lParam.Add(new MySqlParameter("?Email", orcamentoInfo.Email));
                lParam.Add(new MySqlParameter("?Cidade", orcamentoInfo.Cidade));
                lParam.Add(new MySqlParameter("?Uf", orcamentoInfo.UF));
                lParam.Add(new MySqlParameter("?Comentario", orcamentoInfo.Comentario));
                lParam.Add(new MySqlParameter("?Data", orcamentoInfo.Data));

                using (exeComando = new ExecutaComando(cmdInsert, lParam, ConexoesBanco.jvserrinox))
                {
                    var dr = exeComando.GetDataReader();
                    if(dr.Read())
                    {
                        orcamentoInfo.CodOrcamento = int.Parse(dr["CodOrcamento"].ToString());
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
