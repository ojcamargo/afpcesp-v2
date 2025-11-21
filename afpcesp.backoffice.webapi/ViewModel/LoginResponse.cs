namespace afpcesp.backoffice.webapi.ViewModel
{
    /// <summary>
    /// ViewModel de resposta contendo o token JWT e informações do usuário.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Token JWT gerado para autenticação.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora de expiração do token.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Nome de usuário autenticado.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Email do usuário autenticado.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Perfis/roles do usuário.
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();
    }
}
