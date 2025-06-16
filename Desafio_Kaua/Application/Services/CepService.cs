// CepService.cs
using Desafio_Kaua.Application.Interfaces;
using Desafio_Kaua.Domain.DTOs;
using Desafio_Kaua.Domain.Models;
using System.Net.Http.Json;

namespace Desafio_Kaua.Application.Services
{
    public class CepService : ICepService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IEstadoRepository _estadoRepository;

        public CepService(
            IHttpClientFactory httpClientFactory,
            IEnderecoRepository enderecoRepository,
            ICidadeRepository cidadeRepository,
            IEstadoRepository estadoRepository)
        {
            _httpClientFactory = httpClientFactory;
            _enderecoRepository = enderecoRepository;
            _cidadeRepository = cidadeRepository;
            _estadoRepository = estadoRepository;
        }

        // Implementação para o endpoint GET
        public async Task<Endereco?> ObterEnderecoDoBancoAsync(string cep)
        {
            return await _enderecoRepository.ObterPorCepAsync(cep);
        }

        // Implementação para o endpoint POST
        public async Task<Endereco?> ConsultarEGravarEnderecoAsync(string cep)
        {
            // 1. Verifica se o endereço já existe no nosso banco. Se sim, retorna.
            var enderecoExistente = await _enderecoRepository.ObterPorCepAsync(cep);
            if (enderecoExistente != null)
            {
                return enderecoExistente;
            }

            // 2. Se não existe, consulta a API externa ViaCEP.
            var httpClient = _httpClientFactory.CreateClient("ViaCEP");
            var viaCepResponse = await httpClient.GetFromJsonAsync<ViaCepResponseDto>($"https://viacep.com.br/ws/{cep}/json/");

            // 3. Se a API externa não encontrar o CEP, retorna nulo.
            if (viaCepResponse == null || viaCepResponse.Erro)
            {
                return null;
            }

            // 4. Garante que o Estado existe no banco.
            var estado = await ObterOuCriarEstadoAsync(viaCepResponse);

            // 5. Garante que a Cidade existe no banco, associada ao estado correto.
            var cidade = await ObterOuCriarCidadeAsync(viaCepResponse, estado);

            // 6. Cria o novo endereço com as entidades já rastreadas pelo EF Core.
            var novoEndereco = new Endereco(
                viaCepResponse.Cep.Replace("-", ""), // Garante que o CEP não tenha hífens
                viaCepResponse.Logradouro,
                viaCepResponse.Bairro,
                viaCepResponse.Complemento,
                viaCepResponse.Unidade,
                viaCepResponse.Ddd,
                cidade
            );

            await _enderecoRepository.AdicionarAsync(novoEndereco);
            
            // 7. Salva TODAS as alterações (novo endereço, cidade e/ou estado) em uma única transação.
            await _enderecoRepository.SalvarAsync();

            return novoEndereco;
        }

        private async Task<Estado> ObterOuCriarEstadoAsync(ViaCepResponseDto viaCepResponse)
        {
            var estado = await _estadoRepository.ObterPorUfAsync(viaCepResponse.Uf);
            if (estado == null)
            {
                // Para o desafio, vamos assumir que o nome e região podem usar a UF.
                // O ideal é ter os construtores adaptados para isso.
                estado = new Estado(viaCepResponse.Uf, viaCepResponse.Uf, "Desconhecida");
                await _estadoRepository.AdicionarAsync(estado);

            }
            return estado;
        }

        private async Task<Cidade> ObterOuCriarCidadeAsync(ViaCepResponseDto viaCepResponse, Estado estado)
        {
            var cidade = await _cidadeRepository.ObterPorIbgeAsync(viaCepResponse.Ibge);
            if (cidade == null)
            {
                cidade = new Cidade(viaCepResponse.Localidade, viaCepResponse.Ibge, viaCepResponse.Siafi, viaCepResponse.Gia, estado.id, estado);
                await _cidadeRepository.AdicionarAsync(cidade);
            }
            return cidade;
        }
    }
}