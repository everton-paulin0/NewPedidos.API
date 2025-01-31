﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newpedidos.Application.Command.InsertOrder;
using Newpedidos.Application.Command.InsertProduct;
using Newpedidos.Application.Model;
using Newpedidos.Application.Services;
using Newpedidos.Application.Services.Interfaces;

namespace Newpedidos.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
            .AddServices()
            .AddHandler()
            .AddValidation();

            return services;

        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IProductServices, ProductServices>();


            return services;
        }

        private static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertOrderCommand>());

            services.AddTransient<IPipelineBehavior<InsertOrderCommand, ResultViewModel<int>>, ValidateInsertOrderCommandBevahior>();


            //services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProductCommand>());

            //services.AddTransient<IPipelineBehavior<InsertProductCommand, ResultViewModel<int>>, ValidateInsertProductCommandBevahior>();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertOrderCommand>()
                .AddValidatorsFromAssemblyContaining<InsertProductCommand>();

            return services;
        }

    }






}
