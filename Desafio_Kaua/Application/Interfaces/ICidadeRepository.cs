using Desafio_Kaua.Domain.Models;

namespace Desafio_Kaua.Application.Interfaces
{
    public interface ICidadeRepository
    {
        Task AdicionarAsync(Cidade cidade);
        Task<Cidade?> ObterPorIbgeAsync(string ibge);
    }
}