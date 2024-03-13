

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Data;
using WebApi.Extensions;
using WebApi.Models;
using WebApi.Services.Implementations;
using WebApi.Services.Interfaces;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureService(builder);
            ConfigureDb(builder);

            var app = builder.Build();
            

            ConfigurePipeline(app);

            
            var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<UserRole>>();
            
            Seeder.Seed(userManager, roleManager, context);
            app.Run();
        }


        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });
            });

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ITokenService, TokenService>();
        }

        public static void ConfigureDb(WebApplicationBuilder builder)
        {
            builder.Services.ConfigureEntityFramework(builder.Configuration);
        }

     
        public static void ConfigurePipeline(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllers();

        }

        public static void ConfigureAuth(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                 AddJwtBearer(options =>
                 {
                     options.MapInboundClaims = false;

                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                         ValidateAudience = true,
                         ValidAudience = builder.Configuration["JWT:ValidAudience"],
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                     };
                 });
        }
    }
}


