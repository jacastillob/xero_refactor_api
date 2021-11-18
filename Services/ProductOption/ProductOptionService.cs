using System;
using System.Collections.Generic;

namespace RefactorThis.Services
{
    public class ProductOptionService
    {
        protected static ProductOptionService objService = null;
        private ProductOptionDataSource datasource;

        public ProductOptionService(ProductOptionDataSource datasource)
        {
            this.datasource = datasource;
        }

        public static ProductOptionService Instance
        {
            get
            {
                if (objService == null)
                    objService = new ProductOptionService(new SqliteProductOptionsDataSource());

                return objService;
            }
        }
        public List<ProductOption> getProductOptions(Guid productId)
        {
            return datasource.getProductOptions("");
        }
        public ProductOption getProductOption(Guid id)
        {
            return datasource.getProductOption(id);
        }
        public void saveProductOption(ProductOption product)
        {
            product.IsNew = true;
            datasource.saveProductOption(product);
        }
        public void saveProductOption(ProductOption product, Guid id)
        {
            if (datasource.getProductOption(id) != null)
            {
                datasource.saveProductOption(product);
            }
        }
        public void deleteProductOption(Guid id)
        {
            datasource.deleteProductOption(id);
        }
    }
}
