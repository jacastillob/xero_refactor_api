using System;
using System.Collections.Generic;
using RefactorThis;
using RefactorThis.DataSources.Storage;

namespace RefactorThis
{
    public class SqliteProductOptionsDataSource:ProductOptionDataSource
    {
        public SqliteProductOptionsDataSource()
        {
        }
        public void deleteProductOption(Guid id)
        {   
            var cmd = Sqlite.Instance.getConnection().CreateCommand();
            cmd.CommandText = $"delete from productoptions where id = '{id}' collate nocase";
            cmd.ExecuteReader();
        }
      
        public ProductOption getProductOption(Guid id)
        {
            ProductOption productOption = null;
            var cmd = Sqlite.Instance.getConnection().CreateCommand();
            //IsNew = true;
            cmd.CommandText = $"select * from productoptions where id = '{id}' collate nocase";

            var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
                return null;

            productOption = new ProductOption(){
                IsNew = false,
                Id = Guid.Parse(rdr["Id"].ToString()),
                ProductId = Guid.Parse(rdr["ProductId"].ToString()),
                Name = rdr["Name"].ToString(),
                Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString()
            };

            return productOption;
        }

        public List<ProductOption> getProductOptions(Dictionary<string, string> dict)
        {
            List<ProductOption> Items = new List<ProductOption>();
            var cmd = Sqlite.Instance.getConnection().CreateCommand();
            string where=string.Join(dict.)
            cmd.CommandText = $"select id from productoptions WHERE {where}";

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr.GetString(0));
                Items.Add(getProductOption(id));
            }
            return Items;
        }

        public void saveProductOption(ProductOption product)
        {   
            var cmd = Sqlite.Instance.getConnection().CreateCommand();

            cmd.CommandText = product.IsNew
                ? $"insert into productoptions (id, productid, name, description) values ('{product.Id}', '{product.ProductId}', '{product.Name}', '{product.Description}')"
                : $"update productoptions set name = '{product.Name}', description = '{product.Description}' where id = '{product.Id}' collate nocase";

            cmd.ExecuteNonQuery();
        }

    }
}
