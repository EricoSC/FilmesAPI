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
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly EmailService _emailService;
        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CadastrarUsuario(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            IdentityUser<int> userExistis = _userManager.Users.FirstOrDefault(x => x.Email == userIdentity.Email);
            if (userExistis != null)
            {
                return Result.Fail("Email ja cadastrado");
            }
            var resultIdentity = _userManager.CreateAsync(userIdentity, userDto.Password);
            if (resultIdentity.Result.Succeeded)
            {
                var resultrole = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;
                var resultuser = _userManager.AddToRoleAsync(userIdentity, "admin").Result;
                resultrole = _roleManager.CreateAsync(new IdentityRole<int>("ericosa")).Result;
                resultuser = _userManager.AddToRoleAsync(userIdentity, "ericosa").Result;

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
