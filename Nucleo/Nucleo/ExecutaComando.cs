using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nucleo
{
    public class ExecutaComando : BaseDal
    {
        public ExecutaComando(String comando, List<MySqlParameter> param, ConexoesBanco banco)
            : base(banco)
        {
            Sql = new MySqlCommand(comando);
            Sql.CommandType = CommandType.Text;
            Sql.Parameters.Clear();
            if (param != null)
            {
                foreach (MySqlParameter item in param)
                {
                    Sql.Parameters.Add(item);
                }
            }

        }
    }
}
