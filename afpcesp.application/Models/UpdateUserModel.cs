namespace afpcesp.application.Models
{
    /// <summary>
    /// Modelo para atualização de usuário na camada de aplicação.
    /// </summary>
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }
}
