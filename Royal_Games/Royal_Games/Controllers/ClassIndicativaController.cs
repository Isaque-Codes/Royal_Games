using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Applications.Services;
using Royal_Games.Domains;
using Royal_Games.DTOs.ClassIndicativaDto;
using Royal_Games.Exceptions;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassIndicativaController : ControllerBase
    {
        private readonly ClassIndicativaService _service;

        public ClassIndicativaController(ClassIndicativaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerClassIndicativaDto>> Listar()
        {
            List<LerClassIndicativaDto> classIndicativas = _service.Listar();
            return Ok(classIndicativas);
        }

        [HttpGet("{id}")]
        public ActionResult<LerClassIndicativaDto?> ObterPorId(int id)
        {
            LerClassIndicativaDto? classIndicativa = _service.ObterPorId(id);

            if (classIndicativa == null)
            {
                return NotFound();
            }

            return Ok(classIndicativa);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adicionar(CriarClassIndicativaDto criarDto)
        {
            try
            {
                _service.Adicionar(criarDto);
                return StatusCode(201);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Atualizar(int id, CriarClassIndicativaDto criarDto)
        {
            try
            {
                _service.Atualizar(id, criarDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
