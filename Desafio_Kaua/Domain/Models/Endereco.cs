using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Kaua.Domain.Models
{
    [Table("enderecos")]
    public class Endereco
    {
        [Key]
        public string cep { get; protected set; }
        public string logradouro { get; protected set; }
        public string bairro { get; protected set; }
        public string? complemento { get; protected set; }
        public int? unidade { get; protected set; }

        public int cidadeid { get; protected set; }
        public Cidade cidade { get; protected set; }

        protected Endereco() { }

        public Endereco(string cep, string logradouro, string bairro, string? complemento, int? unidade, Cidade cidade)
        {
            this.cep = cep ?? throw new ArgumentNullException(nameof(cep));
            this.logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            this.bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            this.complemento = complemento;
            this.unidade = unidade;
            this.cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            this.cidadeid = cidade.id;
        }
    }
}
