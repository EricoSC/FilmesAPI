using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.FilmeDTO;
using FilmesAPI.Model;
using FilmesAPI.Service;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddFilm(CreateFilmeDto filmedto)
        {
            ReadFilmeDto readDto = _filmeService.AddFilmService(filmedto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadFilmeDto filmeDto = _filmeService.GetFilmById(id);
            if (filmeDto != null) return Ok(filmeDto);
            else return NotFound();
        }

        [HttpGet]
        public IActionResult GetFilm([FromQuery] int? idade = null)
        {
            List<ReadFilmeDto> filmes = _filmeService.GetFilme(idade);
            if (filmes is null) return Ok(filmes);
            else return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.UpdateFilme(id, filmeDto);
            if (resultado.IsFailed) return NotFound();
            else return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            Result result = _filmeService.DeleteFilme(id);
            return result.IsFailed ? NotFound() : NoContent();
        }
    }
}
