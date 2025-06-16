using Desafio_Kaua.Application.Interfaces;
using Desafio_Kaua.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Kaua.Infra.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly ConnectionContext _context;

        public CidadeRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cidade cidade)
        {
            await _context.Cidades.AddAsync(cidade);
        }

        public async Task<Cidade?> ObterPorIbgeAsync(string ibge)
        {
            return await _context.Cidades
                                 .Include(c => c.estado)
                                 .FirstOrDefaultAsync(c => c.ibge == ibge);
        }
    }
}