using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosAPI.Data.Dtos.UserDTO;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Model;

namespace UsuariosAPI.Service
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly EmailService _emailService;
        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastrarUsuario(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            var resultIdentity = _userManager.CreateAsync(userIdentity, userDto.Password);
            if (resultIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[] { userDto.Email }, encodedCode, "Link ativação Email", userIdentity.Id);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao Cadastrar usuario!");
         
        }

        internal Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.Where(u => u.Id == request.UsuarioId).FirstOrDefault();
            var identityResults = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao);
            if (identityResults.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de susuario");
        }
    }
}
