using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using RefactorThis;

namespace RefactorThis
{
    public class SqliteProductDataSource : ProductDataSource
    {
        private SqliteConnection connection;

        public SqliteProductDataSource()
        {
            this.connection = new SqliteConnection("Data Source=App_Data/products.db");
        }

        public List<Product> getProducts()
        {

                    List<Product> Items = new List<Product>();
                    var conn = Helpers.NewConnection();
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = $"select id from Products {where}";

                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var id = Guid.Parse(rdr.GetString(0));
                        Items.Add(new Product(id));
                    }
            throw new NotImplementedException();

        //    public class Products
        //{
        //    public List<Product> Items { get; private set; }

        //    public Products()
        //    {
        //        LoadProducts(null);
        //    }

        //    public Products(string name)
        //    {
        //        LoadProducts($"where lower(name) like '%{name.ToLower()}%'");
        //    }

        //    private void LoadProducts(string where)
        //    {
        //        Items = new List<Product>();
        //        var conn = Helpers.NewConnection();
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        cmd.CommandText = $"select id from Products {where}";

        //        var rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            var id = Guid.Parse(rdr.GetString(0));
        //            Items.Add(new Product(id));
        //        }
        //    }
        //}



    }
}
}
