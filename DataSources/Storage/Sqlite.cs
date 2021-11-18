using System;
using Microsoft.Data.Sqlite;

namespace RefactorThis.DataSources.Storage
{
    public class Sqlite
    {
       

        protected static Sqlite objService = null;
        private const string ConnectionString = "Data Source=App_Data/products.db";

        public Sqlite()
        {   
        }

        public static Sqlite Instance
        {
            get
            {
                if (objService == null)
                    objService = new Sqlite();

                return objService;

            }
        }

        public  SqliteConnection getConnection()
        {
            SqliteConnection con = new SqliteConnection(ConnectionString);
            con.Open();
            return con;
        }

        public void closeConnection(SqliteConnection con)
        {
            con.Close();
        }
    }
}
