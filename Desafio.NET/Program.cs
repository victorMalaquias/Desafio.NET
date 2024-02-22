
using Desafio.NET.Business;
using Desafio.NET.Business.Interfaces;
using Desafio.NET.Database;
using Desafio.NET.Services;
using Desafio.NET.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SqlContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPagadorService, PagadorService>();
            builder.Services.AddScoped<IRecebedorServices, RecebedorServices>();
            builder.Services.AddScoped<IPixService, PixService>();
            builder.Services.AddScoped<IPagadorBusiness, PagadorBusiness>();
            builder.Services.AddScoped<IRecebedorBusiness, RecebedorBusiness>();
            builder.Services.AddScoped<IPixBusiness, PixBusiness>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
