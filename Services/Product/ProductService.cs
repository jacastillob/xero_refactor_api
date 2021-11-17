using System;
using System.Collections.Generic;
using RefactorThis.DataSources;
using RefactorThis.Models;

namespace RefactorThis.Services
{
    public class ProductService
    {
        private ProductDataSource datasource;
        public ProductService(ProductDataSource datasource)
        {
            this.datasource = datasource;
        }

        public List<Product> getProducts()
        {
            return null;
        }
    }
}
