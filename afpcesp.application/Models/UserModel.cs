namespace afpcesp.application.Models
{
    /// <summary>
    /// Modelo de usuário na camada de aplicação.
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
        public bool IsActive { get; set; } = true;
        public int? EmployeeId { get; set; }
    }
}
