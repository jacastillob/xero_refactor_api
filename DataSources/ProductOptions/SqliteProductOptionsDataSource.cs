using System;
using System.Collections.Generic;
using System.Text;
using RefactorThis;
using RefactorThis.DataSources.Storage;
using RefactorThis.Security;

namespace RefactorThis
{
    public class SqliteProductOptionsDataSource : ProductOptionDataSource
    {
        public SqliteProductOptionsDataSource()
        {
        }
        public void deleteProductOption(Guid id)
        {
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                cmd.CommandText = $"delete from productoptions where id = '{id}' collate nocase";
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Error("Problems loading product option", "SqliteProductOptionsDataSource.deleteProductOptionByProductId", 0, ex);
            }
        }
        public void deleteProductOptionByProductId(Guid productId)
        {
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                cmd.CommandText = $"delete from productoptions where productid = '{productId}' collate nocase";
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Error("Problems loading product option", "SqliteProductOptionsDataSource.deleteProductOptionByProductId", 0, ex);
            }

        }
        public ProductOption getProductOption(Guid id)
        {
            ProductOption productOption = null;
            try
            {

                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                //IsNew = true;
                cmd.CommandText = $"select * from productoptions where id = '{id}'  collate nocase";

                var rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                    return null;

                productOption = new ProductOption()
                {
                    Id = Guid.Parse(rdr["Id"].ToString()),
                    ProductId = Guid.Parse(rdr["ProductId"].ToString()),
                    Name = rdr["Name"].ToString(),
                    Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Error("Problems loading product option", "SqliteProductOptionsDataSource.getProductOption", 0, ex);
            }
            return productOption;
        }

        public ProductOption getProductOption(Guid productId, Guid id)
        {
            ProductOption productOption = null;
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                //IsNew = true;
                cmd.CommandText = $"select * from productoptions where id = '{id}' and productid ='{productId}' collate nocase";

                var rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                    return null;

                productOption = new ProductOption()
                {
                    Id = Guid.Parse(rdr["Id"].ToString()),
                    ProductId = Guid.Parse(rdr["ProductId"].ToString()),
                    Name = rdr["Name"].ToString(),
                    Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Error("Problems loading product option", "SqliteProductOptionsDataSource.getProductOption", 0, ex);
            }
            return productOption;
        }
        public List<ProductOption> getProductOptions(Guid productId)
        {
            List<ProductOption> Items = new List<ProductOption>();
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                cmd.CommandText = $"select id from productoptions WHERE productid = '{productId}' ";

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var id = Guid.Parse(rdr.GetString(0));
                    Items.Add(getProductOption(id));
                }
            }
            catch (Exception ex)
            {
                throw new Error("Problems deleting product", "SqliteProductOptionsDataSource.deleteProduct", 0, ex);
            }
            return Items;
        }
        public void saveProductOption(ProductOption product, bool insert)
        {
            try
            {
                var cmd = Sqlite.Instance.getConnection().CreateCommand();
                cmd.CommandText = insert
                    ? $"insert into productoptions (id, productid, name, description) values ('{Guid.NewGuid()}', '{product.ProductId}', '{product.Name}', '{product.Description}')"
                    : $"update productoptions set name = '{product.Name}', description = '{product.Description}' where id = '{product.Id}' collate nocase";

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Error("Problems deleting product option", "SqliteProductOptionsDataSource.deleteProduct", 0, ex);
            }
        }
    }
}
