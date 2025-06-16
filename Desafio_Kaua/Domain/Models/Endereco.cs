using Npgsql.Replication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Kaua.Domain.Models
{
    [Table("enderecos_kaua")]
    public class Endereco
    {
        [Key]
        public string cep { get; private set; }
        public string logradouro { get; private set; }
        public string bairro { get; private set; }
        public string? complemento { get; private set; }
        public string? unidade { get; private set; }
        public string ddd { get; private set; }

        [ForeignKey("cidade")]
        public int cidadeid { get; private set; }
        public Cidade cidade { get; private set; }

        protected Endereco() { }

        public Endereco(string cep, string logradouro, string bairro, string? complemento, string? unidade, string ddd, Cidade cidade)
        {
            this.cep = cep ?? throw new ArgumentNullException(nameof(cep));
            this.logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            this.bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            this.complemento = complemento;
            this.unidade = unidade;
            this.ddd = ddd ?? throw new ArgumentNullException(nameof(ddd));
            this.cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            this.cidadeid = cidade.id;
        }
    }
}
