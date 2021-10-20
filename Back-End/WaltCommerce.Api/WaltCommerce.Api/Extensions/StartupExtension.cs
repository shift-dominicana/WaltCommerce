using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Interfaces.ProductsImages;
using BussinesLayer.Services;
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

namespace WaltCommerce.Api.Extensions
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

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IProductCategorieService, ProductCategorieService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IPersonTypeCategorieService, PersonTypeCategorieService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IProductColorService, ProductColorService>();
            services.AddTransient<IProductImageService, ProductImageService>();
            services.AddTransient<IProductSizeService, ProductSizeService>();
            services.AddTransient<IProductSpecificationService, ProductSpecificationService>();
            services.AddTransient<IBuyCartsService, BuyCartService>();
            services.AddTransient<IBuyCartDetailService, BuyCartDetailService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
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
