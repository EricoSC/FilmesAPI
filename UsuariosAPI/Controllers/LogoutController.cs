using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Service;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly LogoutService _logoutService;
        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }
        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result resultado = _logoutService.DeslogaUsuario(request);
            return resultado.IsFailed ? Unauthorized(resultado.Errors.FirstOrDefault()) : Ok();
        }
    }
}
