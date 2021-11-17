using System;
using System.Collections.Generic;

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
    }
}
