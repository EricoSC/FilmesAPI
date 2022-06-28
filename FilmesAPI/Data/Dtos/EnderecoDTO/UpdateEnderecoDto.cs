using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.EnderecoDTO
{
    public class UpdateEnderecoDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do cinema nao deve ser nullo ou vazio")]
        [StringLength(200)]
        public string Nome { get; set; }
    }
}
