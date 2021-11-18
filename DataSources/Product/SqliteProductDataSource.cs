using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using RefactorThis;
using RefactorThis.DataSources.Storage;

namespace RefactorThis
{
    public class SqliteProductDataSource : ProductDataSource
    {

        public SqliteProductDataSource()
        {
        }

        public Product getProduct(Guid id)
        {
            Product product = null;
            var cmd = Sqlite.Instance.getConnection().CreateCommand();
            cmd.CommandText = $"select * from Products where id = '{id}' collate nocase";

            var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
                return null;

            product = new Product()
            {
                IsNew=false,
                Id = Guid.Parse(rdr["Id"].ToString()),
                Name = rdr["Name"].ToString(),
                Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString(),
                Price = decimal.Parse(rdr["Price"].ToString()),
                DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString())
            };
            return product;
        }

        public List<Product> getProducts()
        {
            List<Product> Items = new List<Product>();
            var cmd = Sqlite.Instance.getConnection().CreateCommand();

            cmd.CommandText = $"Select id from Products ";
            var rdr = cmd.ExecuteReader();
           
            while (rdr.Read())
            {   
                var id = Guid.Parse(rdr.GetString(0));
                Items.Add(getProduct(id));
            }
            return Items;
        }
        public void saveProduct(Product product)
        {
            var cmd = Sqlite.Instance.getConnection().CreateCommand();
            cmd.CommandText = product.IsNew
                ? $"insert into Products (id, name, description, price, deliveryprice) values ('{product.Id}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})"
                : $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";

            cmd.ExecuteNonQuery();
        }

        public void deleteProduct(Guid Id)
        {
            //foreach (var option in new ProductOptions(Id).Items)
            //    option.Delete();

            var cmd = Sqlite.Instance.getConnection().CreateCommand();
            cmd.CommandText = $"delete from Products where id = '{Id}' collate nocase";
            cmd.ExecuteNonQuery();
        }



    }
}
