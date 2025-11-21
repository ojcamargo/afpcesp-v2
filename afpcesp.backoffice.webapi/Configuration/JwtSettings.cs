namespace afpcesp.backoffice.webapi.Configuration
{
    /// <summary>
    /// Configurações para geração e validação de tokens JWT.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Chave secreta para assinar os tokens JWT.
        /// Deve ter no mínimo 32 caracteres para segurança adequada.
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// Emissor do token (issuer).
        /// Identifica quem criou o token.
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// Audiência do token (audience).
        /// Identifica para quem o token é destinado.
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Tempo de expiração do token em minutos.
        /// </summary>
        public int ExpirationMinutes { get; set; } = 60;

        /// <summary>
        /// Define se a validação do emissor está ativa.
        /// </summary>
        public bool ValidateIssuer { get; set; } = true;

        /// <summary>
        /// Define se a validação da audiência está ativa.
        /// </summary>
        public bool ValidateAudience { get; set; } = true;

        /// <summary>
        /// Define se a validação do tempo de vida está ativa.
        /// </summary>
        public bool ValidateLifetime { get; set; } = true;

        /// <summary>
        /// Define se a validação da chave de assinatura está ativa.
        /// </summary>
        public bool ValidateIssuerSigningKey { get; set; } = true;
    }
}
