using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.EnderecoDTO
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public DateTime DataConsutla { get; set; } = DateTime.Now;
    }
}
