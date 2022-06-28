using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Service
{
    public class LogoutService
    {
        private readonly SignInManager<IdentityUser<int>> _signManager;
        public LogoutService(SignInManager<IdentityUser<int>> signManager)
        {
            _signManager = signManager;
        }

        public Result DeslogaUsuario(LoginRequest request)
        {
            var resultIdentity = _signManager.SignOutAsync();
            return resultIdentity.IsCompletedSuccessfully ? Result.Ok() : Result.Fail("Logout Falhou");
        }
    }
}
