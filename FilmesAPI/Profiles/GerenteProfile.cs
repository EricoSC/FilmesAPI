using AutoMapper;
using FilmesAPI.Data.Dtos.GerenteDTO;
using FilmesAPI.Model;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, o => o
                .MapFrom(gerente => gerente.Cinemas
                .Select(c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })
                )
                );
        }
    }
}
