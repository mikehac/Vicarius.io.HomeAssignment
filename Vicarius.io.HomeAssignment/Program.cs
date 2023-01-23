
using Microsoft.Extensions.Configuration;
using Vicarius.io.HomeAssignment.IServices;
using Vicarius.io.HomeAssignment.Services;

namespace Vicarius.io.HomeAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddScoped<IElasticService, ElasticService>();
            builder.Services.AddScoped<IGenericRestHttpClient, GenericRestHttpClient>();
            builder.Services.AddScoped<IGenericRestHttpClient, GenericRestHttpClient>();
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}