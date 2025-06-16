using Desafio_Kaua.Domain.Models;

namespace Desafio_Kaua.Application.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco?> ObterPorCepAsync(string cep);
        Task AdicionarAsync(Endereco endereco);
        Task SalvarAsync();
    }
}
