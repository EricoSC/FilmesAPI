using AutoMapper;
using FilmesAPI.Data.Dtos.CinemaDTO;
using FilmesAPI.Model;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();

        }
    }
}
