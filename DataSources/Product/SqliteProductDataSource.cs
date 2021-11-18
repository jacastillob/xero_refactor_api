using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using RefactorThis;
using RefactorThis.DataSources.Storage;
using RefactorThis.Security;

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
            try
            {

                    var cmd = Sqlite.Instance.getConnection().CreateCommand();
                    cmd.CommandText = $"select * from Products where id = '{id}' collate nocase";

                    var rdr = cmd.ExecuteReader();
                    if (!rdr.Read())
                        return null;

                    product = new Product()
                    {   
                        Id = Guid.Parse(rdr["Id"].ToString()),
                        Name = rdr["Name"].ToString(),
                        Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString(),
                        Price = decimal.Parse(rdr["Price"].ToString()),
                        DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString())
                    };
                
            }catch(Exception ex)
            {
                throw new Error("Problems loading product", "SqliteProductDataSource.getProduct", 0, ex);
            }
            
            return product;

        }

        public List<Product> getProducts()
        {
            List<Product> Items = new List<Product>();
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();

                cmd.CommandText = $"Select id from Products ";
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var id = Guid.Parse(rdr.GetString(0));
                    Items.Add(getProduct(id));
                }
            }
            catch (Exception ex)
            {
                throw new Error("Problems loading product", "SqliteProductDataSource.getProducts", 0, ex);
            }
            return Items;
        }
        public void saveProduct(Product product, bool insert)
        {
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                cmd.CommandText = insert
                    ? $"insert into Products (id, name, description, price, deliveryprice) values ('{Guid.NewGuid()}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})"
                    : $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";

                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new Error("Problems loading product", "SqliteProductDataSource.saveProduct", 0, ex);
            }
        }

        public void deleteProduct(Guid Id)
        {
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                cmd.CommandText = $"delete from Products where id = '{Id}' collate nocase";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Error("Problems deleting product", "SqliteProductDataSource.deleteProduct", 0, ex);
            }
        }



    }
}
