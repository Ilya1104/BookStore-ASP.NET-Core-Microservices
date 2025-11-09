using BookStore.Ordering.Application.Interfaces;
using BookStore.Ordering.Application.Services;
using BookStore.Ordering.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace BookStore.Ordering.Web.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ordering API",
                    Version = "v1"
                });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });

            return builder;
        }

        public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
        {
            /* services.AddDbContext<UserContext>(options => options.UseSqlServer(
     "Data Source=.\\SQLEXPRESS; Database=UserBase; Persist Security Info=False; MultipleActiveResultSets=True; Trusted_Connection=True;"
     ));*/

            builder.Services.AddDbContext<OrderingDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Ordering")));

            return builder;
        }
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBasketService, BasketsService>();
            builder.Services.AddScoped<IOrderingService, OrderingService>();
            return builder;
        }
        public static WebApplicationBuilder AddIntegrationServices(this WebApplicationBuilder builder)
        {
            return builder;
        }
    }
}
