using System;
using System.Collections.Generic;


namespace RefactorThis
{
    public interface ProductDataSource
    {
        List<Product> getProducts();
        Product getProduct(Guid id);
        void saveProduct(Product product, bool insert);
        void deleteProduct(Guid id);
    }
}
