namespace FilmesAPI.Data.Dtos.SessaoDTO
{
    public class CreateSessaoDto
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime TerminoSessao { get; set; }
    }
}
