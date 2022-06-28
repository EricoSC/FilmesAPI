using FilmesAPI.Data.Dtos.CinemaDTO;
using FilmesAPI.Service;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AddCinema(CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AddCinema(cinemaDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetCinemas([FromQuery] string? nomeDoFilme)
        {
            List<ReadCinemaDto> lstCinemaDto = _cinemaService.GetCinemas(nomeDoFilme);
            return lstCinemaDto is null ? NotFound() : Ok(lstCinemaDto);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadCinemaDto readDto = _cinemaService.GetById(id);
            return readDto is null ? NotFound() : Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result serviceResult = _cinemaService.UpdateCinema(id, cinemaDto);
            return serviceResult.IsFailed ? NotFound() : NoContent();
                     
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Result result = _cinemaService.DeleteCinema(id);
            return result.IsFailed ? NotFound() : NoContent();
        }
    }
}
