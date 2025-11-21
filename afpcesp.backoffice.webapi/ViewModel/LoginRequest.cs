using System.ComponentModel.DataAnnotations;

namespace afpcesp.backoffice.webapi.ViewModel
{
    /// <summary>
    /// ViewModel de requisição para autenticação de usuários.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Nome de usuário ou email.
        /// </summary>
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; } = string.Empty;
    }
}
