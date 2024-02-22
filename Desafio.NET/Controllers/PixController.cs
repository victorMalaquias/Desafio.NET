using Desafio.NET.Business.Interfaces;
using Desafio.NET.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.NET.Controllers
{
    [ApiController]
    [Route("api/pix")]
    public class PixController : ControllerBase
    {
        private readonly IPixBusiness _pixBusiness;

        public PixController(IPixBusiness pixBusiness)
        {
            _pixBusiness = pixBusiness;
        }

        [HttpPost("realizarPix")]
        public async Task<IActionResult> RealizarPix([FromBody] PixRequest pixRequest)
        {
            try
            {
                var result = await _pixBusiness.RealizarPix(pixRequest);

                return Ok($"Pix realizado com sucesso! ID da Transação: {result.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao realizar pix: {ex.Message}");
            }
        }

        [HttpGet("transacoes")]
        public async Task<IActionResult> ObterTransacoes()
        {
            try
            {
                var transacoes = await _pixBusiness.ObterTransacoes(); 

                return Ok(transacoes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter transações: {ex.Message}");
            }
        }

    }
}
