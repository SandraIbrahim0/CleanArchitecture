using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Repository;
using CleanArch.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArch.IoC
{
    //Cross Cutting // cross Function that connect all the projects with each other
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //ApplicationServices
            services.AddScoped<IProductService, ProductService>();
            //Data Layer
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ProductService>();

        }
    }
}
