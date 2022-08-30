using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DBUtils
    {

        private static string host = "localhost";
        private static string database = "db_mail";
        private static string port = "5432";
        private static string userid = "postgres";
        private static string password = "postgres";

        public static NpgsqlConnection getConnection()
        {

            string connString = $"User ID={userid};Password={password};Host={host};Port={port};Database={database};";

            return new NpgsqlConnection(connString);

        }

        public static string getHash(string arg)
        {

            MD5 md5 = MD5.Create();

            string hash = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(arg)));

            return hash;

        }

        public static void execQuery(string query)
        {

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            cmd.ExecuteNonQuery();

            connection.Close();

        }

    }
}
