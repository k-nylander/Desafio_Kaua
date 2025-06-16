using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Kaua.Domain.Models
{
    [Table("estados_kaua")]
    public class Estado
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; private set; }
        public string uf { get; private set; }
        public string regiao { get; private set; }

        protected Estado() { }
        public Estado(string nome, string uf, string região)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.uf = uf ?? throw new ArgumentNullException(nameof(uf));
            this.regiao = região ?? throw new ArgumentNullException(nameof(região));
        }
    }
}

