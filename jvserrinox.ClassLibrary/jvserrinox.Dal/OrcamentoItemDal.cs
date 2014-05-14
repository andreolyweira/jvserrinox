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
    public class OrcamentoItemDal
    {
        const string cmdInsert = @"
        INSERT INTO jvserrinox.OrcamentoItem
        (Quantidade,OrcamentoItem_CodProduto,OrcamentoItem_CodOrcamento)
        VALUES
        (?Quantidade,?OrcamentoItem_CodProduto,?OrcamentoItem_CodOrcamento);select LAST_INSERT_ID() as CodOrcamentoItem";

        public bool Inserir(OrcamentoItemInfo orcamentoItemInfo)
        {
            ExecutaComando exeComando = null;
            List<MySqlParameter> lParam = new List<MySqlParameter>();

            try
            {
                lParam.Add(new MySqlParameter("?Quantidade", orcamentoItemInfo.Quantidade));
                lParam.Add(new MySqlParameter("?OrcamentoItem_CodProduto", orcamentoItemInfo.OrcamentoItem_CodProduto));
                lParam.Add(new MySqlParameter("?OrcamentoItem_CodOrcamento", orcamentoItemInfo.OrcamentoItem_CodOrcamento));

                using (exeComando = new ExecutaComando(cmdInsert, lParam, ConexoesBanco.jvserrinox))
                {
                    var dr = exeComando.GetDataReader();
                    if(dr.Read())
                    {
                        orcamentoItemInfo.CodOrcamentoItem = int.Parse(dr["CodOrcamentoItem"].ToString());
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
