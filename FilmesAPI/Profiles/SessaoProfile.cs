using AutoMapper;
using FilmesAPI.Data.Dtos.SessaoDTO;
using FilmesAPI.Model;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.InicioSessao, opts => opts
                .MapFrom(dto => dto.TerminoSessao.AddMinutes(dto.Filme.DuracaoMin * (-1)))
                );
        }
    }
}
