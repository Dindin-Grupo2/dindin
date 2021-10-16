using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Dindin.DAO
{
    public class ConexaoBanco
    {
        static string connectionString = "datasource=;port=;username=;password=;database=;SslMode=none";
        
        static MySqlConnection conn = new MySqlConnection(connectionString);

        static public int? executaComando(string sql, bool queroID)
        {
            int ID = 0;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                if (queroID)
                {
                    cmd.Parameters.Add(new MySqlParameter("ultimoId", cmd.LastInsertedId));
                    ID = Convert.ToInt32(cmd.Parameters["@ultimoId"].Value);
                    return ID;
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return null;
        }

        static public DataTable retornaDados(string sql)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
