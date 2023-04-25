using Application.Test.MockData;
using CleanArch.Data.Context;
using CleanArch.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ProductRepositoryTests
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async void Should_Return_Product_ListAsync()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("DatabaseTest").Options;
            using var context = new ProductDBContext(dbOptions);
            context.AddRange(ProductMockData.AddDBProducts());
            context.SaveChanges();

            //Act
            var repo = new ProductRepository(context);

            var products = await repo.Get();
            int count = await products.CountAsync();

            //Assert
            Assert.Equal<int>(2, count);
        }
    }
}