using Desafio_Kaua.Application.DTOs;
using Desafio_Kaua.Application.Interfaces;
using Desafio_Kaua.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Kaua.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly ICepService _cepService;

        public EnderecoController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        [ProducesResponseType(typeof(EnderecoViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        public async Task<IActionResult> GetCep([FromRoute] string cep)
        {
            var endereco = await _cepService.ObterEnderecoDoBancoAsync(cep);

            if (endereco == null)
            {
                return NotFound(new ErrorViewModel("CEP não consta na base de dados."));
            }

            var viewModel = EnderecoViewModel.FromModel(endereco);
            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EnderecoViewModel), 201)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        public async Task<IActionResult> PostCep([FromBody] CepRequestDto request)
        {
            var endereco = await _cepService.ConsultarEGravarEnderecoAsync(request.Cep);

            if (endereco == null)
            {
                return NotFound(new ErrorViewModel("CEP não encontrado no serviço externo ViaCEP."));
            }

            var viewModel = EnderecoViewModel.FromModel(endereco);

            return CreatedAtAction(nameof(GetCep), new { cep = viewModel.Cep }, viewModel);
        }
    }
}