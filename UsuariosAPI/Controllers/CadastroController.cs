using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos.UserDTO;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Service;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _cadastroService;
        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService; 
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            Result results = _cadastroService.CadastrarUsuario(userDto);
            return results.IsFailed ? StatusCode(500) : Ok(results.Successes.FirstOrDefault());
        }
        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery]AtivaContaRequest request)
        {
            Result results = _cadastroService.AtivaContaUsuario(request);
            return results.IsFailed ? StatusCode(500) : Ok(results.Successes.FirstOrDefault());

        }
    }


}
