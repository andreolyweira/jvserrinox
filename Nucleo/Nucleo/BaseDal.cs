using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Nucleo
{
    public class BaseDal : IDisposable
    {
        private MySqlConnection connection;
        private MySqlCommand sql;

        public MySqlCommand Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public BaseDal(ConexoesBanco banco)
        {
            Connection = new MySqlConnection();
            if (banco == ConexoesBanco.jvserrinox)
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["jvserrinox"].ToString();
        }

        public void openConnection()
        {
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro com o banco de dados, tente novamente em instantes.");
            }
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            try
            {
                openConnection();
                Sql.Connection = Connection;
                dt.Load(Sql.ExecuteReader());
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message, exc);
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }

        public MySqlDataReader GetDataReader()
        {
            try
            {
                openConnection();
                Sql.Connection = Connection;
                return Sql.ExecuteReader();
            }
            catch (Exception exc)
            {
                Connection.Close();
                throw new Exception(exc.Message, exc);
            }
            finally
            {

            }
        }

        public int ExecuteScalar()
        {
            try
            {
                openConnection();
                Sql.Connection = Connection;
                return Convert.ToInt32(Sql.ExecuteScalar());
            }
            catch (Exception exc)
            {
                Connection.Close();
                throw new Exception(exc.Message, exc);
            }
        }

        public int ExecuteQuery()
        {
            int rowsaffected = 0;

            try
            {

                openConnection();
                Sql.Connection = Connection;
                rowsaffected = Sql.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message, exc);
            }

            return rowsaffected;
        }
        
        public void Dispose()
        {
            if (Connection != null && Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
