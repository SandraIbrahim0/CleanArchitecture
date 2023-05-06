using Application.Test.MockData;
using CleanArch.Data.Context;
using CleanArch.Data.Repository;
using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        [Fact]
        public async void Should_Save_Product()
        {
            var dbOptions = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("DatabaseTest").Options;
            using var context = new ProductDBContext(dbOptions);

            var product = new Product { Description = "Description test1", Id = 1, Name = "Name Test1", Price = 1000, Quantity = 1 };

            var repo = new ProductRepository(context);
            repo.Add(product);

            var products = await repo.Get();
            var productsContextList = await context.Product.ToListAsync();
            var productSingle = Assert.Single<Product>(productsContextList);
        }
    }
}