using Desafio_Kaua.Application.Interfaces;
using Desafio_Kaua.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Kaua.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ConnectionContext _context;

        public EnderecoRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
        }

        public async Task<Endereco?> ObterPorCepAsync(string cep)
        {
            return await _context.Enderecos
                                 .Include(e => e.cidade)
                                 .ThenInclude(c => c.estado)
                                 .FirstOrDefaultAsync(e => e.cep == cep);
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}