namespace Desafio_Kaua.Domain.Models
{
    public interface IEnderecoRepository
    {
        Task<Endereco?> ObterPorCepAsync(string cep);
        Task AdicionarAsync(Endereco endereco);
        Task SalvarAsync();
    }
}
