using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Applications.Services;
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
        public ActionResult<List<LerClassDto>> Listar()
        {
            List<LerClassDto> classIndicativas = _service.Listar();

            return Ok(classIndicativas);
        }

        [HttpGet("{id}")]
        public ActionResult<LerClassDto> ObterPorId(int id)
        {
            LerClassDto classDto = _service.ObterPorId(id);

            if (classDto == null)
            {
                return NotFound();
            }

            return Ok(classDto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adicionar(CriarClassDto criarDto)
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
        public ActionResult Atualizar(int id, CriarClassDto atualizarDto)
        {
            try
            {
                _service.Atualizar(id, atualizarDto);

                return NoContent();
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
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