

using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Identity;
using WebApi.Data;
using WebApi.Extensions;
using WebApi.Models;

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

            app.Run();
        }


        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }

        public static void ConfigureAuth()
        {

        }
    }
}


