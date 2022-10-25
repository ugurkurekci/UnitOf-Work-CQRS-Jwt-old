using Business.Abstract;
using Business.Concrete;
using Domain;
using Domain.Data.EFCore;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Concretes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Security.JWT.Services.Abstraction;
using Security.JWT.Services.Concrete;
using System.Reflection;

namespace Business;
public static class ServiceProvider
{
    public static void MyDependencyInjections(this IServiceCollection services)
    {

        // DbContext
        services.AddScoped<ProjectDataContext>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IRefreshTokenValidator, RefreshTokenValidator>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();


    }
}
