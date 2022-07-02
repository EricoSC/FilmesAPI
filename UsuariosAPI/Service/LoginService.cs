using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Model;

namespace UsuariosAPI.Service
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.ToList());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result ChangePass(ChangePasswordRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUsuarioByEmail(request.Email);
            IdentityResult resultadoIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha Redefinida com sucesso");
            return Result.Fail(resultadoIdentity.Errors.ToArray().ToString());

        }

        

        public Result ResetPass(PasswordResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUsuarioByEmail(request.Email);
            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager
                    .UserManager
                    .GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }
            return Result.Fail("erro pra recuperar");
        }

        private IdentityUser<int> RecuperarUsuarioByEmail(string email)
        {
            return _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}
