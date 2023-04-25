using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System.Collections.Generic;

namespace Application.Test.MockData
{
    public class ProductMockData
    {
        public static List<ProductViewModel> GetProducts()
        {
            return new List<ProductViewModel>
            {
                new ProductViewModel{ Description="Description test1",Id=1,Name="Name Test1", Price=1000 ,Quantity =1 },
                new ProductViewModel{ Description="Description test2",Id=2,Name="Name Test2", Price=2000 ,Quantity =2 }
            };
        }
        public static List<Product> AddDBProducts()
        {
            return new List<Product>
            {
                new Product{ Description="Description test1",Id=1,Name="Name Test1", Price=1000 ,Quantity =1 },
                new Product{ Description="Description test2",Id=2,Name="Name Test2", Price=2000 ,Quantity =2 }
            };
        }
    }
}

