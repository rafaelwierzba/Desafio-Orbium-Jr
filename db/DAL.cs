using Npgsql;
using System.Data;

namespace Orbium_Desafio_Jr_RVW.db
{
    public class DAL // => DAL = Data Acces Layer
    {
        private static string Server = "localhost";
        private static string Database = "desafio_orbium_jr";
        private static string User = "postgres";
        private static string Pass = "0707";
        private static string connString = $"Host={Server};Username={User};Password={Pass};Database={Database}";
        private static NpgsqlConnection Conn;

        public DAL()
        {
            Conn = new NpgsqlConnection(connString);
            Conn.Open();
        }

        //Recebe como Argumento uma String c o comando SELECT
        public DataTable ReturnDataTable(string query)
        {
            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand(query, Conn);
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(cmd);
            adapt.Fill(dt);
            return dt;
        }

        //Recebe como Argumento uma String c o comando INSERT, UPDATE ou DELETE
        public void CRUD(string query)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(query, Conn);
            cmd.ExecuteNonQuery();
        }

    }

}

