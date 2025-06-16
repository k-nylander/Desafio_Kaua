using Desafio_Kaua.Domain.Models;

namespace Desafio_Kaua.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Ddd { get; set; }

        public static EnderecoViewModel FromModel(Endereco enderecoModel)
        {
            return new EnderecoViewModel
            {
                Cep = enderecoModel.cep,
                Logradouro = enderecoModel.logradouro,
                Complemento = enderecoModel.complemento,
                Bairro = enderecoModel.bairro,
                Cidade = enderecoModel.cidade.nome,
                Uf = enderecoModel.cidade.estado.uf,
                Ddd = enderecoModel.ddd
            };
        }
    }
}