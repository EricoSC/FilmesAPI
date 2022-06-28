using FilmesAPI.Model;

namespace FilmesAPI.Data.Dtos.CinemaDTO
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
        public DateTime DataConsutla { get; set; } = DateTime.Now;
    }
}
