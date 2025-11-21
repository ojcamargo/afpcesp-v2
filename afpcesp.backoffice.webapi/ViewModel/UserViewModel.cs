namespace afpcesp.backoffice.webapi.ViewModel
{
    /// <summary>
    /// ViewModel para representação de usuário nas requisições da API.
    /// </summary>
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
    }

    /// <summary>
    /// ViewModel para criação de usuário.
    /// </summary>
    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    /// ViewModel para atualização de usuário.
    /// </summary>
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
    }
}
