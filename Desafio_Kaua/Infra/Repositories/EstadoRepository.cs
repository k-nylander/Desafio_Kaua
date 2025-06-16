using Desafio_Kaua.Application.Interfaces;
using Desafio_Kaua.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Kaua.Infra.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ConnectionContext _context;

        public EstadoRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Estado estado)
        {
            await _context.Estados.AddAsync(estado);
        }

        public async Task<Estado?> ObterPorUfAsync(string uf)
        {
            return await _context.Estados.FirstOrDefaultAsync(e => e.uf.ToUpper() == uf.ToUpper());
        }
    }
}