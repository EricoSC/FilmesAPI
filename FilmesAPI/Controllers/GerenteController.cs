using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDTO;
using FilmesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class GerenteController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;
        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadGerenteDto>(gerente)); 

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(f => f.Id == id);
            if (gerente is null)
            {
                return NotFound();
            }
            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
