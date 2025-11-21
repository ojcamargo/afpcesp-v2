using System.Security.Claims;
using AutoFixture;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using afpcesp.backoffice.webapi.Controller;
using afpcesp.backoffice.webapi.ViewModel;
using afpcesp.application.Models;
using afpcesp.application.Services;

namespace afpcesp.webapi.tests
{
    public class AuthControllerTests
    {
        private readonly IAuthApplicationService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly AuthController _controller;
        private readonly Fixture _fixture;

        public AuthControllerTests()
        {
            _authService = Substitute.For<IAuthApplicationService>();
            _logger = Substitute.For<ILogger<AuthController>>();
            _controller = new AuthController(_authService, _logger);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsOkWithToken()
        {
            // Arrange
            var loginRequest = _fixture.Build<LoginRequest>()
                .With(x => x.Username, "testuser")
                .With(x => x.Password, "testpassword")
                .Create();

            var authResponse = _fixture.Build<AuthResponseModel>()
                .With(x => x.Token, "valid-token")
                .With(x => x.Username, "testuser")
                .Create();

            _authService.AuthenticateAsync(Arg.Any<LoginModel>()).Returns(authResponse);

            // Act
            var result = await _controller.Login(loginRequest);

            // Assert
            var okResult = Assert.IsType<ActionResult<LoginResponse>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(okResult.Result);
            var response = Assert.IsType<LoginResponse>(okObjectResult.Value);
            Assert.Equal("valid-token", response.Token);
            Assert.Equal("testuser", response.Username);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginRequest = _fixture.Build<LoginRequest>()
                .With(x => x.Username, "invaliduser")
                .With(x => x.Password, "wrongpassword")
                .Create();

            _authService.AuthenticateAsync(Arg.Any<LoginModel>()).Returns((AuthResponseModel?)null);

            // Act
            var result = await _controller.Login(loginRequest);

            // Assert
            var actionResult = Assert.IsType<ActionResult<LoginResponse>>(result);
            Assert.IsType<UnauthorizedObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Login_WithInvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            var loginRequest = _fixture.Create<LoginRequest>();
            _controller.ModelState.AddModelError("Username", "Required");

            // Act
            var result = await _controller.Login(loginRequest);

            // Assert
            var actionResult = Assert.IsType<ActionResult<LoginResponse>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void GetCurrentUser_WithAuthenticatedUser_ReturnsUserInfo()
        {
            // Arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "testuser"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = _controller.GetCurrentUser();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void ValidateToken_WithValidToken_ReturnsOk()
        {
            // Arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "testuser")
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = _controller.ValidateToken();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }
    }
}
