using Desafio_Kaua.Application.Interfaces;
using Desafio_Kaua.Application.Services;
using Desafio_Kaua.Infra;
using Desafio_Kaua.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Kaua
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ProductionConnection");

            builder.Services.AddDbContext<ConnectionContext>(options =>
                options.UseNpgsql(connectionString)
            );
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
            builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
            builder.Services.AddScoped<ICepService, CepService>();

            builder.Services.AddHttpClient("ViaCEP")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        SslProtocols = System.Security.Authentication.SslProtocols.None
                    };
                });

            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

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