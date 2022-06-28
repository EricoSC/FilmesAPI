using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDTO;
using FilmesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult AddSessao(CreateSessaoDto sessaoDto )
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = sessao.Id }, sessao);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto readSessao = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(readSessao);
            }
            else
                return NotFound();
        }

    }
}
