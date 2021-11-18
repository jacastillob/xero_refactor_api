using System;
using RefactorThis.Services;
using Xunit;

namespace RefactorThis.Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public void getProducts()
        {
            Assert.NotEmpty(ProductService.Instance.getProducts());
        }
        [Fact]
        public void getProduct()
        {
            Guid Id = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3");
            Assert.True(ProductService.Instance.getProduct(Id).Id == Id);
        }
    }
}
