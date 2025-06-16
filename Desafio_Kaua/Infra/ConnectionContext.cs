// Arquivo: Infra/ConnectionContext.cs

using Microsoft.EntityFrameworkCore;
using Desafio_Kaua.Domain.Models;

namespace Desafio_Kaua.Infra
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura a tabela 'estados_kaua'
            modelBuilder.Entity<Estado>(eb =>
            {
                eb.ToTable("estados_kaua");
                eb.HasKey(e => e.id);
                // --- LINHA DA SOLUÇÃO ---
                // Informa ao EF Core para usar a estratégia de identidade padrão do PostgreSQL (SERIAL, IDENTITY)
                eb.Property(e => e.id).UseIdentityByDefaultColumn();
            });

            // Configura a tabela 'cidades_kaua'
            modelBuilder.Entity<Cidade>(eb =>
            {
                eb.ToTable("cidades_kaua");
                eb.HasKey(c => c.id);
                // --- LINHA DA SOLUÇÃO ---
                eb.Property(c => c.id).UseIdentityByDefaultColumn();
            });

            // A tabela 'enderecos_kaua' não precisa disso, pois sua chave primária 'cep' é uma string.
            modelBuilder.Entity<Endereco>().ToTable("enderecos_kaua");
        }
    }
}