namespace afpcesp.application.Models
{
    /// <summary>
    /// Modelo para criação de usuário na camada de aplicação.
    /// </summary>
    public class CreateUserModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? EmployeeId { get; set; }
    }
}
