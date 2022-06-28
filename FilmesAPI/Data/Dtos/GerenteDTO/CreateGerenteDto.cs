using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.GerenteDTO
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage = "Nome do Gerente nao deve ser nullo ou vazio")]
        [StringLength(200)]
        public string Nome { get; set; }
    }
}
