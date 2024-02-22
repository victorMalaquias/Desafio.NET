using Desafio.NET.Business.Interfaces;
using Desafio.NET.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.NET.Controllers
{
    [ApiController]
    [Route("api/recebedores")]
    public class RecebedorController : ControllerBase
    {
        private readonly IRecebedorBusiness _recebedorBusiness;

        public RecebedorController(IRecebedorBusiness recebedorBusiness)
        {
            _recebedorBusiness = recebedorBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> ObterRecebedores()
        {
            try
            {
                var recebedor = await _recebedorBusiness.ObterRecebedores();
                if (recebedor == null)
                {
                    return NotFound();
                }

                return Ok(recebedor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter recebedor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterRecebedor(int id)
        {
            try
            {
                var recebedor = await _recebedorBusiness.ObterRecebedor(id);
                if (recebedor == null)
                {
                    return NotFound();
                }

                return Ok(recebedor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter recebedor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarRecebedor([FromBody] Recebedor recebedor)
        {
            try
            {
                var recebedorCriado = await _recebedorBusiness.CriarRecebedor(recebedor);
                return Ok($"Recebedor {recebedorCriado.Id} criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar recebedor: {ex.Message}");
            }
        }
    }
}
