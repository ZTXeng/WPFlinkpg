using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFlnkPG
{
    public static class DPHelper
    {
        //填入自己数据库的账号和密码
        private static string ConnectionString = "Server=localHost;database=postgres;uid=postgres;Password=123456";

        private static Npgsql.NpgsqlConnection Con
        {
            get
            {
                var conn = new Npgsql.NpgsqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
        }

        public static NpgsqlCommand Cmd => Con.CreateCommand();

        public static NpgsqlDataReader SelectForReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                cmd.Connection.Close();
                return null;
            }
        }

        public static bool Updata(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            finally 
            {

                cmd.Connection.Close();
            }
        }
    }
}
