using System;
using System.Collections.Generic;
using Xunit;

namespace RefactorThis.Services
{
    public class ProductService
    {
        protected static ProductService objService = null;
        private ProductDataSource datasource;

        public ProductService(ProductDataSource datasource)
        {
            this.datasource = datasource;
        }
        public static ProductService Instance
        {
            get
            {
                if (objService == null)
                    objService = new ProductService(new SqliteProductDataSource());

                return objService;
            }
        }
        public List<Product> getProducts()
        {   
            return datasource.getProducts();
        }
        public Product getProduct(Guid id)
        {
            return datasource.getProduct(id);
        }
        public void saveProduct(Product product)
        {    
             product.Id = Guid.NewGuid();
             datasource.saveProduct(product,true);
        }
        public void saveProduct(Product product,Guid id)
        {
            if (datasource.getProduct(id) != null  )
            {
                product.Id = id;
                datasource.saveProduct(product,false);
            }
        }
        public void deleteProduct(Guid id)
        {
            ProductOptionService.Instance.deleteProductOptionByProductId(id);
            datasource.deleteProduct(id);
        }
    }
    
}
