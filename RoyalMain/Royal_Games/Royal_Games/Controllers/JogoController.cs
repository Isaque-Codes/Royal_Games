using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Royal_Games.Applications.Services;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.Exceptions;
using System.Security.Claims;

namespace Royal_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoService _service;

        public JogoController(JogoService service)
        {
            _service = service;
        }

        // Autenticação do usuário
        private int ObterUsuarioIdLogado()
        {
            // Busca o ID  do usuário no token
            // ClaimTypes.NameIdentifier geralmente guarda esse ID
            string? idTexto = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(idTexto))
            {
                throw new DomainException("Usuário não autenticado.");
            }

            // Converte o ID de string para int
            // Claims sempre armazenam dados como string
            return int.Parse(idTexto);
        }

        [HttpGet]
        public ActionResult<List<LerJogoDto>> Listar()
        {
            List<LerJogoDto> jogos = _service.Listar();

            return StatusCode(200, jogos);
        }

        [HttpGet("{id}")]
        public ActionResult ObterPorId(int id)
        {
            LerJogoDto jogo = _service.ObterPorId(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return Ok(jogo);
        }

        [HttpGet("{id}/imagem")]
        public ActionResult ObterImagem(int id)
        {
            try
            {
                var imagem = _service.ObterImagem(id);

                return File(imagem, "image/jpeg");
            }

            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        //[Authorize]
        public ActionResult Adicionar([FromForm] CriarJogoDto jogoDto)
        {
            try
            {
                int usuarioId = ObterUsuarioIdLogado();
                _service.Adicionar(jogoDto);

                return StatusCode(201, jogoDto);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        //[Authorize]
        public ActionResult Atualizar(int id, [FromForm] AtualizarJogoDto jogoDto)
        {
            try
            {
                _service.Atualizar(id, jogoDto);

                return NoContent();
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize]
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
