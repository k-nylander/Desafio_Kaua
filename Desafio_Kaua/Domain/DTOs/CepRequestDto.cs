using System.ComponentModel.DataAnnotations;

namespace Desafio_Kaua.Application.DTOs
{
    public class CepRequestDto
    {
        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter exatamente 8 dígitos numéricos.")]
        public string Cep { get; set; }
    }
}