using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.EnderecoDTO;
using FilmesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {

        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IActionResult GetEndereco()
        {
            return Ok(_mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto readFilme = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(readFilme);
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (endereco is null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (endereco is null)
            {
                return NotFound();
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
