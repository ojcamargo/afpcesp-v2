using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using afpcesp.application.Models;

namespace afpcesp.application.Services
{
    /// <summary>
    /// Configurações JWT para a camada de aplicação.
    /// </summary>
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; } = 60;
    }

    /// <summary>
    /// Implementação do serviço de autenticação na camada de aplicação.
    /// </summary>
    public class AuthApplicationService : IAuthApplicationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AuthApplicationService> _logger;

        public AuthApplicationService(IOptions<JwtSettings> jwtSettings, ILogger<AuthApplicationService> logger)
        {
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
        }

        /// <summary>
        /// Autentica um usuário e retorna dados de autenticação.
        /// </summary>
        public async Task<AuthResponseModel?> AuthenticateAsync(LoginModel loginModel)
        {
            try
            {
                // Valida as credenciais do usuário
                var isValid = await ValidateCredentialsAsync(loginModel.Username, loginModel.Password);
                
                if (!isValid)
                {
                    _logger.LogWarning("Tentativa de login falhou para o usuário: {Username}", loginModel.Username);
                    return null;
                }

                // TODO: Buscar informações do usuário no banco de dados
                // Por enquanto, usando dados fictícios
                var email = $"{loginModel.Username}@afpcesp.com.br";
                var roles = new List<string> { "User", "Admin" };

                // Gera o token JWT
                var token = GenerateJwtToken(loginModel.Username, email, roles);
                var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes);

                _logger.LogInformation("Token JWT gerado com sucesso para o usuário: {Username}", loginModel.Username);

                return new AuthResponseModel
                {
                    Token = token,
                    ExpiresAt = expiresAt,
                    Username = loginModel.Username,
                    Email = email,
                    Roles = roles
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao autenticar usuário: {Username}", loginModel.Username);
                return null;
            }
        }

        /// <summary>
        /// Gera um token JWT com as claims do usuário.
        /// </summary>
        public string GenerateJwtToken(string username, string? email, List<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            if (!string.IsNullOrEmpty(email))
            {
                claims.Add(new Claim(ClaimTypes.Email, email));
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Valida as credenciais do usuário.
        /// TODO: Implementar validação real contra o banco de dados.
        /// </summary>
        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            await Task.CompletedTask;
            
            // Para fins de demonstração, aceita qualquer usuário com senha "123456"
            // TODO: Implementar validação real com banco de dados e hash de senha
            return !string.IsNullOrEmpty(username) && password == "123456";
        }
    }
}
