﻿using AutoMapper;
using BussinesLayer.Interfaces.Auth;
using BussinesLayer.Interfaces.Brands;
using BussinesLayer.Interfaces.BuyCartDetails;
using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Interfaces.Mails;
using BussinesLayer.Interfaces.OrderDetails;
using BussinesLayer.Interfaces.Orders;
using BussinesLayer.Interfaces.PersonsTypeCategories;
using BussinesLayer.Interfaces.Products;
using BussinesLayer.Interfaces.ProductsCategories;
using BussinesLayer.Interfaces.ProductsColors;
using BussinesLayer.Interfaces.ProductsImages;
using BussinesLayer.Interfaces.ProductsSizes;
using BussinesLayer.Interfaces.ProductsSpecifications;
using BussinesLayer.Interfaces.Roles;
using BussinesLayer.Interfaces.UserAddresses;
using BussinesLayer.Interfaces.Users;
using BussinesLayer.Services.Auth;
using BussinesLayer.Services.Brands;
using BussinesLayer.Services.BuyCartDetails;
using BussinesLayer.Services.BuyCarts;
using BussinesLayer.Services.Mails;
using BussinesLayer.Services.OrderDetails;
using BussinesLayer.Services.Orders;
using BussinesLayer.Services.PersonsTypeCategories;
using BussinesLayer.Services.Products;
using BussinesLayer.Services.ProductsCategories;
using BussinesLayer.Services.ProductsColors;
using BussinesLayer.Services.ProductsImages;
using BussinesLayer.Services.ProductsSizes;
using BussinesLayer.Services.ProductsSpecifications;
using BussinesLayer.Services.Roles;
using BussinesLayer.Services.UserAddresses;
using BussinesLayer.Services.Users;
using DataLayer.Contexts;
using DataLayer.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Api.Extensions
{
    public static class StartupExtension
    {

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection(nameof(JwtSetting)));

            services.AddDbContext<MainDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("MainDb")));

        }

        public static void ServicesImplementations(this IServiceCollection services)
        {

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IProductsCategoriesService, ProductsCategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IBrandsService, BrandsService>();
            services.AddTransient<IPersonsTypeCategoriesService, PersonsTypeCategoriesService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IProductsColorsService, ProductsColorsService>();
            services.AddTransient<IProductsImagesService, ProductsImagesService>();
            services.AddTransient<IProductsSizesService, ProductsSizesService>();
            services.AddTransient<IProductsSpecificationsService, ProductsSpecificationsService>();
            services.AddTransient<IBuyCartsService, BuyCartsService>();
            services.AddTransient<IBuyCartDetailsService, BuyCartDetailsService>();
            services.AddTransient<IUserAddressesService, UserAddressesService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IMailService, MailService>();



        }

        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                var mainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(c => c.GetName().Name == "DataLayer");
                cfg.AddMaps(mainAssembly);
                cfg.AllowNullCollections = true;
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo() { Title = "Ecommerce Api", Version = "v1", });
                opt.AddSecurityDefinition("SecretKey", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="SecretKey"
                            }
                        }, new List<string>()
                    }
                });
            });

        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(build =>
            {
                build.AddPolicy(nameof(Startup), _ => _.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        public static void ConfigureSwaggerMiddleWare(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce Api");
                opt.RoutePrefix = "swagger";
            });
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection(nameof(JwtSetting))[nameof(JwtSetting.ValidIssuer)],
                    ValidAudience = configuration.GetSection(nameof(JwtSetting))[nameof(JwtSetting.ValidAudience)],
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration.GetSection(nameof(JwtSetting))[nameof(JwtSetting.SecretKey)])),
                    ClockSkew = TimeSpan.Zero
                });

        }

        public static void ConfigureAddControllers(this IServiceCollection services)
        {
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public static void ConfigureMail(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));
        }

    }
}
