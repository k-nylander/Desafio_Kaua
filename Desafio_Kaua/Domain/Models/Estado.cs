using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Kaua.Domain.Models
{
    [Table("estados")]
    public class Estado
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; private set; }
        public string uf { get; private set; }
        public string região { get; private set; }

        protected Estado() { }
    }
}

