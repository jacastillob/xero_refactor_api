using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RefactorThis;
using RefactorThis.Services;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        [HttpGet]
        public List<Product> Get()
        {
            return ProductService.Instance.getProducts();
        }
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return ProductService.Instance.getProduct(id);
        }
        [HttpPost]
        public void SaveProduct(Product product)
        {
             ProductService.Instance.saveProduct(product);
        }
        [HttpPut("{id}")]
        public void UpdateProduct(Guid id, Product product)
        {
            ProductService.Instance.saveProduct(product,id);
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(Guid id)
        {
            ProductService.Instance.deleteProduct(id);
        }

        
    }
}