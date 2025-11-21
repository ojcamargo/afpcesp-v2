using AutoFixture;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using afpcesp.application.Models;
using afpcesp.application.Services;
using afpcesp.dataaccess.models;
using afpcesp.dataaccess.repository;

namespace afpcesp.application.tests
{
    public class UserApplicationServiceTests
    {
        private readonly IBaseRepository<Usuario> _userRepository;
        private readonly ILogger<UserApplicationService> _logger;
        private readonly UserApplicationService _service;
        private readonly Fixture _fixture;

        public UserApplicationServiceTests()
        {
            _userRepository = Substitute.For<IBaseRepository<Usuario>>();
            _logger = Substitute.For<ILogger<UserApplicationService>>();
            _service = new UserApplicationService(_userRepository, _logger);
            _fixture = new Fixture();
            
            // Configurar AutoFixture para omitir recursão em entidades do EF
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsUserList()
        {
            // Arrange
            var entities = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, 1)
                .CreateMany(3)
                .ToList();
            
            _userRepository.GetAllAsync().Returns(entities);

            // Act
            var result = await _service.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            await _userRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task GetUserByIdAsync_WithExistingId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var entity = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, userId)
                .Create();
            
            _userRepository.GetByIdAsync(userId).Returns(entity);

            // Act
            var result = await _service.GetUserByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            await _userRepository.Received(1).GetByIdAsync(userId);
        }

        [Fact]
        public async Task GetUserByIdAsync_WithNonExistingId_ReturnsNull()
        {
            // Arrange
            var userId = 999;
            _userRepository.GetByIdAsync(userId).Returns((Usuario)null!);

            // Act
            var result = await _service.GetUserByIdAsync(userId);

            // Assert
            Assert.Null(result);
            await _userRepository.Received(1).GetByIdAsync(userId);
        }

        [Fact]
        public async Task CreateUserAsync_WithValidData_ReturnsCreatedUser()
        {
            // Arrange
            var createModel = _fixture.Build<CreateUserModel>()
                .With(x => x.Username, "newuser")
                .Create();
            
            var createdEntity = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, 1)
                .With(x => x.DsLogin, createModel.Username)
                .Create();
            
            _userRepository.AddAsync(Arg.Any<Usuario>()).Returns(createdEntity);

            // Act
            var result = await _service.CreateUserAsync(createModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createModel.Username, result.Username);
            await _userRepository.Received(1).AddAsync(Arg.Any<Usuario>());
        }

        [Fact]
        public async Task UpdateUserAsync_WithExistingUser_ReturnsTrue()
        {
            // Arrange
            var userId = 1;
            var updateModel = _fixture.Build<UpdateUserModel>()
                .With(x => x.Id, userId)
                .Create();
            
            var existingEntity = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, userId)
                .Create();
            
            _userRepository.GetByIdAsync(userId).Returns(existingEntity);

            // Act
            var result = await _service.UpdateUserAsync(updateModel);

            // Assert
            Assert.True(result);
            await _userRepository.Received(1).GetByIdAsync(userId);
            await _userRepository.Received(1).UpdateAsync(Arg.Any<Usuario>());
        }

        [Fact]
        public async Task UpdateUserAsync_WithNonExistingUser_ReturnsFalse()
        {
            // Arrange
            var userId = 999;
            var updateModel = _fixture.Build<UpdateUserModel>()
                .With(x => x.Id, userId)
                .Create();
            
            _userRepository.GetByIdAsync(userId).Returns((Usuario)null!);

            // Act
            var result = await _service.UpdateUserAsync(updateModel);

            // Assert
            Assert.False(result);
            await _userRepository.Received(1).GetByIdAsync(userId);
            await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<Usuario>());
        }

        [Fact]
        public async Task DeleteUserAsync_WithExistingUser_ReturnsTrue()
        {
            // Arrange
            var userId = 1;
            var entity = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, userId)
                .Create();
            
            _userRepository.GetByIdAsync(userId).Returns(entity);

            // Act
            var result = await _service.DeleteUserAsync(userId);

            // Assert
            Assert.True(result);
            await _userRepository.Received(1).GetByIdAsync(userId);
            await _userRepository.Received(1).DeleteAsync(userId);
        }

        [Fact]
        public async Task DeleteUserAsync_WithNonExistingUser_ReturnsFalse()
        {
            // Arrange
            var userId = 999;
            _userRepository.GetByIdAsync(userId).Returns((Usuario)null!);

            // Act
            var result = await _service.DeleteUserAsync(userId);

            // Assert
            Assert.False(result);
            await _userRepository.Received(1).GetByIdAsync(userId);
            await _userRepository.DidNotReceive().DeleteAsync(userId);
        }
    }
}
