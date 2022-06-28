using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDTO
{
    public class CreateCinemaDto
    {
     
        [Required(ErrorMessage = "Nome do cinema nao deve ser nullo ou vazio")]
        [StringLength(200)]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
