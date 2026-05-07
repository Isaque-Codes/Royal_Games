using api.Applications.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogJogoController : ControllerBase
    {
        private readonly LogAlteracaoJogoService _service;

        public LogJogoController(LogAlteracaoJogoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("jogo/{id}")]
        public ActionResult ObterPorJogo(int id)
        {
            return Ok(_service.ObterPorJogo(id));
        }
    }
}