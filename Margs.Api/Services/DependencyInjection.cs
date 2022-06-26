using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Margs.Api.Database.Context;
using Margs.Api.Services.Authentication;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services;

public static class DependencyInjection
{
    private const string Jwt = "ApiSettings:JwtSetting";
    private const string AnyOriginPolicy = "AnyOriginPolicy";

    public static IServiceCollection Di(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(c =>
            c.AddPolicy(AnyOriginPolicy, options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(x => true)
                .AllowCredentials()));


        services.AddResponseCaching();

        services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
            options.Providers.Add<BrotliCompressionProvider>();
            options.MimeTypes =
                ResponseCompressionDefaults.MimeTypes.Concat(
                    new[]
                    {
                        "image/svg+xml",
                        "application/json",
                        "application/xml",
                        "text/css",
                        "text/json",
                        "text/plain",
                        "text/xml",
                        "application/vnd.android.package-archive"
                    });
        });


        #region Jwt

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;

                options.SaveToken = true;

                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                            expires > DateTime.UtcNow,
                        ValidateAudience = false,
                        ValidateIssuer = false, // ????????
                        ValidateActor = false,
                        ValidateLifetime = true,
                        ValidIssuer = config["ApiSettings:JwtSetting:Issuer"],
                        ValidAudience = config["ApiSettings:JwtSetting:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["ApiSettings:JwtSetting:SecretKey"]))
                    };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;

                        if (!string.IsNullOrEmpty(accessToken) &&
                            path.StartsWithSegments("/hub"))
                            // Read the token out of the query string
                            context.Token = accessToken;

                        return Task.CompletedTask;
                    }
                };
            });

        #endregion

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddControllers()
            .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        #region swagger

        services.AddSwaggerGen(_ =>
        {
            _.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Margs API",
                Version = "v1",
                Description = "Margs API Developed by Amirhossein Sami",
                TermsOfService = new Uri("https://marg.ir/terms-of-service"),
                Contact = new OpenApiContact
                {
                    Name = "Amirhossein Sami",
                    Email = "amirhossein.sami1275@gmail.com",
                    Url = new Uri("https://marg.ir/amirhossein-sami")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });
            _.OrderActionsBy(apiDesc =>
                $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.RelativePath}_{apiDesc.HttpMethod}");

            var securityScheme = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Description =
                    "JWT Authorization header using the Bearer scheme." +
                    "\r\n\r\n" +
                    "Enter TOKEN in the text input below." +
                    "\r\n\r\n" +
                    "Example: 'a1.b2.c3'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            };

            _.AddSecurityDefinition("Bearer", securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    securityScheme, new[]
                    {
                        "Bearer"
                    }
                }
            };

            _.AddSecurityRequirement(securityRequirement);

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            _.IncludeXmlComments(xmlPath);

            _.UseInlineDefinitionsForEnums();
        });

        #endregion

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.Configure<JwtSetting>(config.GetSection(Jwt));
        return services;
    }
}