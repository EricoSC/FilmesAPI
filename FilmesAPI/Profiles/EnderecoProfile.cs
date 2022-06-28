using AutoMapper;
using FilmesAPI.Data.Dtos.EnderecoDTO;
using FilmesAPI.Model;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();

        }
    }
}
