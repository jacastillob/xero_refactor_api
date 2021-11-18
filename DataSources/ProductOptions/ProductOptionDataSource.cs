using System;
using System.Collections.Generic;
using RefactorThis;

namespace RefactorThis
{
    public interface ProductOptionDataSource
    {
        List<ProductOption> getProductOptions(Guid productId);
        ProductOption getProductOption(Guid productId,Guid Id);
        ProductOption getProductOption(Guid Id);
        void saveProductOption(ProductOption product, bool insert);
        void deleteProductOption(Guid id);
        void deleteProductOptionByProductId(Guid productId);
    }
}
