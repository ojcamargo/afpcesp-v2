using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using afpcesp.backoffice.webapi.ViewModel;
using afpcesp.backoffice.webapi.Mappers;
using afpcesp.application.Services;

namespace afpcesp.backoffice.webapi.Controller
{
    /// <summary>
    /// Controller responsável pela autenticação de usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplicationService _authService;
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// Construtor do AuthController.
        /// </summary>
        public AuthController(IAuthApplicationService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint para autenticação de usuários.
        /// Retorna um token JWT válido se as credenciais estiverem corretas.
        /// </summary>
        /// <param name="loginRequest">Credenciais de login do usuário.</param>
        /// <returns>Token JWT e informações do usuário.</returns>
        /// <response code="200">Login realizado com sucesso. Retorna o token JWT.</response>
        /// <response code="400">Dados de requisição inválidos.</response>
        /// <response code="401">Credenciais inválidas.</response>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Converte ViewModel para Model
            var loginModel = ViewModelMapper.ToLoginModel(loginRequest);
            
            // Chama o serviço da camada Application
            var authResponse = await _authService.AuthenticateAsync(loginModel);

            if (authResponse == null)
            {
                _logger.LogWarning("Tentativa de login falhou para o usuário: {Username}", loginRequest.Username);
                return Unauthorized(new { message = "Usuário ou senha inválidos" });
            }

            _logger.LogInformation("Usuário autenticado com sucesso: {Username}", loginRequest.Username);
            
            // Converte Model para ViewModel
            var response = ViewModelMapper.ToLoginResponse(authResponse);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint protegido para testar a autenticação.
        /// Requer um token JWT válido no header Authorization.
        /// </summary>
        /// <returns>Informações do usuário autenticado.</returns>
        /// <response code="200">Retorna as informações do usuário autenticado.</response>
        /// <response code="401">Token inválido ou ausente.</response>
        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetCurrentUser()
        {
            var username = User.Identity?.Name;
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

            return Ok(new
            {
                username,
                claims,
                message = "Token válido! Você está autenticado."
            });
        }

        /// <summary>
        /// Endpoint para verificar se o token é válido.
        /// </summary>
        /// <returns>Status de validação do token.</returns>
        /// <response code="200">Token válido.</response>
        /// <response code="401">Token inválido ou expirado.</response>
        [HttpGet("validate")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult ValidateToken()
        {
            return Ok(new { valid = true, message = "Token válido" });
        }
    }
}
