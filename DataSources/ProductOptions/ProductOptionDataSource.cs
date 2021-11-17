using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis
{
    public interface ProductOptionDataSource
    {
        List<ProductOption> getProductOptions();
    }
}
