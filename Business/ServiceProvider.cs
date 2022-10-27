using Business.Abstract;
using Business.Concrete;
using Domain;
using Domain.Data.EFCore;
using Domain.Entities;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Base;
using Domain.Repositories.Concretes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Security;
using Security.JWT;
using Security.JWT.Services.Abstraction;
using Security.JWT.Services.Concrete;
using System.Reflection;

namespace Business;

public static class ServiceProvider
{

    public static void MyDependencyInjections(this IServiceCollection services)
    {

        // DbContext
        services.AddTransient<ProjectDataContext>();


        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //AutoMapperExtensions

        //AutoMappers
        services.AddMediatR(typeof(IAssemblyMarker).Assembly);

        // Repositories

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IRefreshTokenValidator, RefreshTokenValidator>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<ITokenGetService, TokenGetService>();
        services.AddScoped<JwtSettings>();


    }

}