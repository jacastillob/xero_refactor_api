using System;
using RefactorThis.Services;
using Xunit;

namespace RefactorThis.Tests
{
    public class ProductOptionServiceTest
    {
        [Fact]
        public void getProductOptions()
        {
            Guid Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3");
            Assert.NotEmpty(ProductOptionService.Instance.getProductOptions(Id));
        }
        [Fact]
        public void getProductOption()
        {
            Guid ProdId = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3");
            Guid Id = new Guid("01234567-89ab-cdef-0123-456789abcdef");
            Assert.True(ProductOptionService.Instance.getProductOption(ProdId, Id).Id == Id);
        }
    }
}
