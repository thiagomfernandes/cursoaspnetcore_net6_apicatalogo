using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Models
{
    public class Usuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
    }

    public class UsuarioToken
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
