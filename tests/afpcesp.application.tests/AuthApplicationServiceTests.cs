using AutoFixture;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;
using afpcesp.application.Models;
using afpcesp.application.Services;

namespace afpcesp.application.tests
{
    public class AuthApplicationServiceTests
    {
        private readonly ILogger<AuthApplicationService> _logger;
        private readonly AuthApplicationService _service;
        private readonly Fixture _fixture;
        private readonly JwtSettings _jwtSettings;

        public AuthApplicationServiceTests()
        {
            _logger = Substitute.For<ILogger<AuthApplicationService>>();
            _fixture = new Fixture();
            
            _jwtSettings = new JwtSettings
            {
                SecretKey = "ThisIsAVerySecretKeyForTestingPurposesOnly123456789",
                Issuer = "TestIssuer",
                Audience = "TestAudience",
                ExpirationMinutes = 60
            };

            var options = Options.Create(_jwtSettings);
            _service = new AuthApplicationService(options, _logger);
        }

        [Fact]
        public async Task AuthenticateAsync_WithValidCredentials_ReturnsAuthResponse()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Username = "testuser",
                Password = "123456"
            };

            // Act
            var result = await _service.AuthenticateAsync(loginModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
            Assert.NotNull(result.Token);
            Assert.NotEmpty(result.Token);
            Assert.True(result.ExpiresAt > DateTime.UtcNow);
            Assert.Contains("User", result.Roles);
            Assert.Contains("Admin", result.Roles);
        }

        [Fact]
        public async Task AuthenticateAsync_WithInvalidCredentials_ReturnsNull()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Username = "testuser",
                Password = "wrongpassword"
            };

            // Act
            var result = await _service.AuthenticateAsync(loginModel);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GenerateJwtToken_WithValidData_ReturnsToken()
        {
            // Arrange
            var username = "testuser";
            var email = "test@example.com";
            var roles = new List<string> { "Admin", "User" };

            // Act
            var token = _service.GenerateJwtToken(username, email, roles);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
            // Token JWT deve ter 3 partes separadas por pontos
            Assert.Equal(3, token.Split('.').Length);
        }

        [Fact]
        public void GenerateJwtToken_WithNullEmail_ReturnsValidToken()
        {
            // Arrange
            var username = "testuser";
            string? email = null;
            var roles = new List<string> { "User" };

            // Act
            var token = _service.GenerateJwtToken(username, email, roles);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }

        [Fact]
        public async Task ValidateCredentialsAsync_WithValidPassword_ReturnsTrue()
        {
            // Arrange
            var username = "testuser";
            var password = "123456";

            // Act
            var result = await _service.ValidateCredentialsAsync(username, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateCredentialsAsync_WithInvalidPassword_ReturnsFalse()
        {
            // Arrange
            var username = "testuser";
            var password = "wrongpassword";

            // Act
            var result = await _service.ValidateCredentialsAsync(username, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task ValidateCredentialsAsync_WithEmptyUsername_ReturnsFalse()
        {
            // Arrange
            var username = "";
            var password = "123456";

            // Act
            var result = await _service.ValidateCredentialsAsync(username, password);

            // Assert
            Assert.False(result);
        }
    }
}
