namespace afpcesp.application.Models
{
    /// <summary>
    /// Modelo de requisição de login na camada de aplicação.
    /// </summary>
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
