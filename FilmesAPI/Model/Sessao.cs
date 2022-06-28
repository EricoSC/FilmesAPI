using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Model
{
    public class Sessao
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int CinemaId { get; set; }

        public DateTime TerminoSessao { get; set; }
    }
}
