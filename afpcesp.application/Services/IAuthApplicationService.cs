using afpcesp.application.Models;

namespace afpcesp.application.Services
{
    /// <summary>
    /// Interface para serviços de autenticação na camada de aplicação.
    /// </summary>
    public interface IAuthApplicationService
    {
        /// <summary>
        /// Autentica um usuário e retorna dados de autenticação.
        /// </summary>
        /// <param name="loginModel">Dados de login do usuário.</param>
        /// <returns>Resposta contendo o token e informações do usuário.</returns>
        Task<AuthResponseModel?> AuthenticateAsync(LoginModel loginModel);

        /// <summary>
        /// Gera um token JWT para um usuário.
        /// </summary>
        /// <param name="username">Nome do usuário.</param>
        /// <param name="email">Email do usuário.</param>
        /// <param name="roles">Perfis/roles do usuário.</param>
        /// <returns>Token JWT gerado.</returns>
        string GenerateJwtToken(string username, string? email, List<string> roles);

        /// <summary>
        /// Valida as credenciais do usuário.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha.</param>
        /// <returns>True se as credenciais são válidas, false caso contrário.</returns>
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }
}
