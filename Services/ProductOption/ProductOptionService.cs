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
            return datasource.getProductOptions(productId);
        }
        public ProductOption getProductOption(Guid productId,Guid id)
        {
            return datasource.getProductOption(productId,id);
        }
        public void saveProductOption(ProductOption product, Guid productId)
        {
            product.ProductId = productId;
            datasource.saveProductOption(product,true);
        }
        public void updateProductOption(ProductOption product, Guid id)
        {
            if (datasource.getProductOption(id) != null)
            {   
                datasource.saveProductOption(product,false);
            }
        }

        public void deleteProductOption(Guid id)
        {
            datasource.deleteProductOption(id);
        }

        public void deleteProductOptionByProductId(Guid productId)
        {
            datasource.deleteProductOptionByProductId(productId);
        }
        
    }
}
