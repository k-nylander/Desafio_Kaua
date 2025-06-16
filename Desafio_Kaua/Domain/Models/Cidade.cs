using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Kaua.Domain.Models
{
    [Table("cidades_kaua")]
    public class Cidade
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; private set; }
        public string ibge { get; private set; }
        public string? siafi { get; private set; }
        public string? gia { get; private set; }

        [ForeignKey("estado")]
        public int estadoid { get; set; }
        public Estado estado { get; private set; }

        protected Cidade() { }
        public Cidade(string nome, string ibge, string? siafi, string? gia, int estadoId, Estado estado)
        {
            this.nome = nome;
            this.ibge = ibge;
            this.siafi = siafi;
            this.gia = gia;
            this.estadoid = estadoId;
            this.estado = estado ?? throw new ArgumentNullException(nameof(estado));
        }
    }
}
