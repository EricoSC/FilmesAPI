using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Model
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O Titulo do Filme é Obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="O Diretor do Filme é Obrigatório")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O Genero do Filme é Obrigatório")]
        [StringLength(10,ErrorMessage ="Genero só pode ter no máximo 30 caracteres seu merda")]
        public string Genero { get; set; }
        [Range(1,210,ErrorMessage ="Duração de Filme muito longa, só pode de 1 a 210 minutos")]
        public int DuracaoMin { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
