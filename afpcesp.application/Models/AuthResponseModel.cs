namespace afpcesp.application.Models
{
    /// <summary>
    /// Modelo de resposta de autenticação na camada de aplicação.
    /// </summary>
    public class AuthResponseModel
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
