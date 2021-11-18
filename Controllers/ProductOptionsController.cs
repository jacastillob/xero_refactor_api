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
        [HttpGet("{productId}/options")]
        public List<ProductOption> GetProductOptions(Guid productId)
        {   
            return ProductOptionService.Instance.getProductOptions(productId);
        }

        [HttpGet("{productId}/options/{id}")]
        public ProductOption GetProductOptionById(Guid productId, Guid id)
        {
            return ProductOptionService.Instance.getProductOptionById(id);
        }

        [HttpPost("{productId}/options")]
        public void CreateOption(Guid productId, ProductOption option)
        {
            option.ProductId = productId;
            option.Save();
        }

        [HttpPut("{productId}/options/{id}")]
        public void UpdateOption(Guid id, ProductOption option)
        {
            var orig = new ProductOption(id)
            {
                Name = option.Name,
                Description = option.Description
            };

            if (!orig.IsNew)
                orig.Save();
        }

        [HttpDelete("{productId}/options/{id}")]
        public void DeleteOption(Guid id)
        {
            var opt = new ProductOption(id);
            opt.Delete();
        }

    }
}
