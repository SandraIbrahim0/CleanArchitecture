﻿using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Context;
using CleanArch.Data.Repository;
using CleanArch.Domain.Commands;
using CleanArch.Domain.CommandsHandlers;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;



namespace CleanArch.IoC
{
    //Cross Cutting // cross Function that connect all the projects with each other
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Domain Handlers
            services.AddScoped<IRequestHandler<CreateProductCommand, bool>, ProductCommandHandler>();

            //ApplicationServices
            services.AddScoped<IProductService, ProductService>();
            //Data Layer
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ProductService>();
            services.AddScoped<ProductDBContext>();


        }
    }
}
