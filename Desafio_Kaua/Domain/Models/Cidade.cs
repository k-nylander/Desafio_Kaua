using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Kaua.Domain.Models
{
    [Table("cidades")]
    public class Cidade
    {
        [Key]
        public int id { get; protected set; }
        public string nome { get; protected set; }
        public string? ibge { get; protected set; }
        public string? siafi { get; protected set; }
        public string? gia { get; protected set; }
        public Estado estado { get; protected set; }

        protected Cidade() { }
        public Cidade(int id, string nome, string? ibge, string? siafi, string gia, Estado estado)
        {
            this.id = id;
            this.nome = nome;
            this.ibge = ibge;
            this.siafi = siafi;
            this.gia = gia;
            this.estado = estado;
        }
    }
}
