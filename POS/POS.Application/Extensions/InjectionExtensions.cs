﻿using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces;
using POS.Application.Services;
using System.Reflection;

namespace POS.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic)); //Inyectando a nivel global los servicios  de fluentValidation
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            services.AddScoped<ICategoryApplication, CategoryApplication>();

            return services;
        }

    }

}
