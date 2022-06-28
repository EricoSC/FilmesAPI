using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Model
{
    public class Cinema
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do cinema nao deve ser nullo ou vazio")]
        [StringLength(200)]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int GerenteId { get; set; }
        public virtual Gerente Gerente { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
