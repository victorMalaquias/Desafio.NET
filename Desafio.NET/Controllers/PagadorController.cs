using Desafio.NET.Business.Interfaces;
using Desafio.NET.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.NET.Controllers
{

    [ApiController]
    [Route("api/pagadores")]
    public class PagadorController : ControllerBase
    {
        private readonly IPagadorBusiness _pagadorBusiness;

        public PagadorController(IPagadorBusiness pagadorBusiness)
        {
            _pagadorBusiness = pagadorBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPagador()
        {
            try
            {
                var pagador = await _pagadorBusiness.ObterPagadores();
                if (pagador == null)
                {
                    return NotFound();
                }

                return Ok(pagador);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter pagador: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPagador(int id)
        {
            try
            {
                var pagador = await _pagadorBusiness.ObterPagador(id);
                if (pagador == null)
                {
                    return NotFound();
                }

                return Ok(pagador);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter pagador: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarPagador([FromBody] Pagador pagador)
        {
            try
            {
                var pagadorCriado = await _pagadorBusiness.CriarPagador(pagador);
                return Ok($"Pagador {pagadorCriado.Id} criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar pagador: {ex.Message}");
            }
        }
    }

}
