using FilmesAPI.Model;

namespace FilmesAPI.Data.Dtos.SessaoDTO
{
    public class ReadSessaoDto
    {
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public int Id { get; set; }
        public DateTime TerminoSessao { get; set; }
        public DateTime InicioSessao { get; set; }

    }
}
