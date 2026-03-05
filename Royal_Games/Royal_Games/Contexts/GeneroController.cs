using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Applications.Services;
using Royal_Games.DTOs.GeneroDto;

namespace Royal_Games.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _service;

        public GeneroController(GeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerGeneroDto>> Listar()
        {
            List<LerGeneroDto> generos = _service.Listar();
            return StatusCode(200, generos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerGeneroDto> ObterPorId(int id)
        {
            LerGeneroDto genero = _service.ObterPorId(id);
            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        [HttpPost]
        //[Authorize]

        public ActionResult Adicionar(CriarGeneroDto criarDto)
        {
            try
            {
                _service.Adicionar(criarDto);
                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize]
        public ActionResult Atualizar(int id, CriarGeneroDto atualizarDto)
        {
            try
            {
                _service.Atualizar(id, atualizarDto);
                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
