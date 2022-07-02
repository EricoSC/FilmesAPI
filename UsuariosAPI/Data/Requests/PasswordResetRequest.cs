using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class PasswordResetRequest
    {
        [Required]
        public string Email { get; set; }
        
    }
}
