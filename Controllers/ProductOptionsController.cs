using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RefactorThis.Services;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        [HttpGet("{productId}/option")]
        public List<ProductOption> GetProductOptions(Guid productId)
        {   
            return ProductOptionService.Instance.getProductOptions(productId);
        }

        [HttpGet("{productId}/option/{id}")]
        public ProductOption GetProductOptionById(Guid productId, Guid id)
        {
            return ProductOptionService.Instance.getProductOption(productId,id);
        }

        [HttpPost("{productId}/option")]
        public void SaveProductOption(Guid productId, ProductOption option)
        {
             ProductOptionService.Instance.saveProductOption(option,productId);
        }

        [HttpPut("{productId}/option/{id}")]
        public void UpdateProductOption(Guid id, ProductOption option)
        {
            ProductOptionService.Instance.updateProductOption(option, id);
        }

        [HttpDelete("{productId}/option/{id}")]
        public void DeleteProductOption(Guid id)
        {

            ProductOptionService.Instance.deleteProductOption(id);
            
        }

    }
}
