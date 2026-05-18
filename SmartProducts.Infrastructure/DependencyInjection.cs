using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartProducts.Application.Interfaces;
using SmartProducts.Infrastructure.Authentication;
using SmartProducts.Infrastructure.Persistence;
using SmartProducts.Infrastructure.Repositories;
using SmartProducts.Infrastructure.Services;

namespace SmartProducts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IProductService, ProductService>();

        var jwtSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtSection);

        services.AddScoped<JwtService>();

        services.AddScoped<RefreshTokenService>();

        return services;
    }
}