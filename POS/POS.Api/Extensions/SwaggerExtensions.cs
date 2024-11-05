using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "Punto de Venta API 2022",
                TermsOfService = new Uri("https://opensource.org/licences/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "SIR TECH S.A.C.",
                    Email = "sirtech@gmail.com",
                    Url = new Uri("https://sirtech.com.pe"),
                },
                License = new OpenApiLicense
                {
                    Name = "Use under Lick",
                    Url = new Uri("https://opensource.org/licences/NIT"),
                }

            };

            services.AddSwaggerGen(gen =>
            {
                openApi.Version = "v1";
                gen.SwaggerDoc("v1", openApi);

                var securitySheme = new OpenApiSecurityScheme
                {
                    Name = "HWT Authentication",
                    Description = "JWT Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    }
                };
                gen.AddSecurityDefinition(securitySheme.Reference.Id, securitySheme);
                gen.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securitySheme, new string[] { } }
                });

            });
            return services;

        }

    }
}
