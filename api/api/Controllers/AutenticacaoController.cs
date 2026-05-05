using api.Applications.Services;
using api.DTOs.AutenticacaoDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Applications.Services;
using api.DTOs.AutenticacaoDto;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoService _service;

        public AutenticacaoController(AutenticacaoService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public ActionResult<TokenDto> Login(LoginDto loginDto)
        {
            try
            {
                var token = _service.Login(loginDto);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
