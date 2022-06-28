using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.CinemaDTO;
using FilmesAPI.Model;
using FluentResults;

namespace FilmesAPI.Service
{
    public class CinemaService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AddCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> GetCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (!string.IsNullOrWhiteSpace(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas where cinema.Sessoes.Any(s => s.Filme.Titulo == nomeDoFilme) select cinema;
                cinemas = query.ToList();
            }
            if (cinemas is null)
            {
                return null;
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto GetById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
            if (cinema is null) return null;
            else return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public Result UpdateCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema is null)
            {
                Result.Fail("Cinema nao encontrado");
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return Result.Ok();
        }
        public Result DeleteCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema is null)
            {
                Result.Fail("Cinema nao encontrado");
            }
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
