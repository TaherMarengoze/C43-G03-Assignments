using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Store.Api.Factories;

namespace Store.Api.Extensions;

public static class PresentationServicesExtension
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(opt =>
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory =
                ApiResponseFactory.CustomValidationErrorResponse;
        });

        services.ConfigureSwagger();

        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Store API",
                Version = "v1",
                Description = "Provides API endpoints for the Store application.",
            });

            options.AddSecurityDefinition(
                name: "Bearer",
                securityScheme: new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Bearer Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt",
                }
            );

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme },
                    },
                    new List<string>()
                }
            });
        });

        return services;
    }
}
