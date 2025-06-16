using Desafio_Kaua.Domain.Models;

namespace Desafio_Kaua.Application.Interfaces
{
    public interface ICepService
    {
        Task<Endereco?> ObterEnderecoDoBancoAsync(string cep);
        Task<Endereco?> ConsultarEGravarEnderecoAsync(string cep);
    }
}