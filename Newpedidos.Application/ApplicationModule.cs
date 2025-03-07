using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newpedidos.Application.Command.InsertOrder;
using Newpedidos.Application.Command.InsertProduct;
using Newpedidos.Application.Command.InsertUser;
using Newpedidos.Application.Model;
using Newpedidos.Application.Services;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Infractruture.Auth;

namespace Newpedidos.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services
            .AddServices()
            .AddHandler()
            .AddValidation()
            .AddAuth(configuration);

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
                .AddValidatorsFromAssemblyContaining<InsertUserCommand>()
                .AddValidatorsFromAssemblyContaining<InsertProductCommand>();

            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    }; 

                });
            return services;
        }
    }
}
