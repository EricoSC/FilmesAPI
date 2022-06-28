using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.FilmeDTO;
using FilmesAPI.Model;
using FluentResults;

namespace FilmesAPI.Service
{
    public class FilmeService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AddFilmService(CreateFilmeDto filmedto)
        {
            Filme filme = _mapper.Map<Filme>(filmedto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public ReadFilmeDto GetFilmById(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null) return null;
            return _mapper.Map<ReadFilmeDto>(filme);

        }

        public List<ReadFilmeDto> GetFilme(int? idade)
        {
            List<Filme> filmes;

            if (idade is null) filmes = _context.Filmes.ToList();
            else filmes = _context.Filmes.Where(f => f.ClassificacaoEtaria <= idade).ToList();
            if (filmes is null) return null;
            
            return _mapper.Map<List<ReadFilmeDto>>(filmes);
        }

        public Result UpdateFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme is null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme is null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
