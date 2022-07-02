using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Service;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            return resultado.IsFailed ? Unauthorized() : Ok(resultado.Successes.FirstOrDefault());
        }
        [HttpPost("/solicita-reset")]
        public IActionResult ResetPassword(PasswordResetRequest request)
        {
            Result resultado = _loginService.ResetPass(request);
            return resultado.IsFailed ? Unauthorized() : Ok(resultado.Successes.FirstOrDefault());
        }
        [HttpPost("/efetua-reset")]
        public IActionResult ChangePassword(ChangePasswordRequest request)
        {
            Result resultado = _loginService.ChangePass(request);
            return resultado.IsFailed ? Unauthorized() : Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
