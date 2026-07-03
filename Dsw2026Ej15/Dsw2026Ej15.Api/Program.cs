using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dsw2026Ej15.Api.Middleware;
using Microsoft.EntityFrameworkCore;


namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Dsw2026Ej15DbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddHealthChecks();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IPersistence, PersistenceEf>();

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            


            app.MapControllers();
            app.MapHealthChecks("/health-check");

            app.Run();
        }
    }
}
