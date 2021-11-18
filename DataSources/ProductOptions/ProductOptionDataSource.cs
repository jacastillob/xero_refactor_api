using System;
using System.Collections.Generic;
using RefactorThis;

namespace RefactorThis
{
    public interface ProductOptionDataSource
    {
        List<ProductOption> getProductOptions(Dictionary<string,string> dict);
        ProductOption getProductOption(Guid id);
        void saveProductOption(ProductOption product);
        void deleteProductOption(Guid id);
    }
}
