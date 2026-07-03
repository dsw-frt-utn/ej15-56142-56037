using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dsw2026Ej15.Api.Middleware;


namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHealthChecks();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlingMiddleware>();


            app.MapControllers();
            app.MapHealthChecks("/health-check");

            app.Run();
        }
    }
}
