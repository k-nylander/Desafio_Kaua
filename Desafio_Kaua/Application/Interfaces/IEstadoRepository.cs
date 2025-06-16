using Desafio_Kaua.Domain.Models;

namespace Desafio_Kaua.Application.Interfaces
{
    public interface IEstadoRepository
    {
        Task AdicionarAsync(Estado estado);
        Task<Estado?> ObterPorUfAsync(string uf);
    }
}