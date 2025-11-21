using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;
using afpcesp.backoffice.webapi.Controller;
using afpcesp.backoffice.webapi.ViewModel;
using afpcesp.application.Models;
using afpcesp.application.Services;

namespace afpcesp.webapi.tests
{
    public class UserControllerTests
    {
        private readonly IUserApplicationService _userService;
        private readonly UserController _controller;
        private readonly Fixture _fixture;

        public UserControllerTests()
        {
            _userService = Substitute.For<IUserApplicationService>();
            _controller = new UserController(_userService);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOkWithUserList()
        {
            // Arrange
            var users = _fixture.CreateMany<UserModel>(3).ToList();
            _userService.GetAllUsersAsync().Returns(users);

            // Act
            var result = await _controller.GetAllUsers();

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<UserViewModel>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(okResult.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<UserViewModel>>(okObjectResult.Value);
            Assert.Equal(3, returnedUsers.Count());
        }

        [Fact]
        public async Task GetUserById_WithExistingId_ReturnsOkWithUser()
        {
            // Arrange
            var userId = 1;
            var user = _fixture.Build<UserModel>()
                .With(x => x.Id, userId)
                .Create();
            _userService.GetUserByIdAsync(userId).Returns(user);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            var okResult = Assert.IsType<ActionResult<UserViewModel>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(okResult.Result);
            var returnedUser = Assert.IsType<UserViewModel>(okObjectResult.Value);
            Assert.Equal(userId, returnedUser.Id);
        }

        [Fact]
        public async Task GetUserById_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var userId = 999;
            _userService.GetUserByIdAsync(userId).Returns((UserModel?)null);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserViewModel>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task CreateUser_WithValidData_ReturnsCreatedAtAction()
        {
            // Arrange
            var createRequest = _fixture.Create<CreateUserRequest>();
            var createdUser = _fixture.Build<UserModel>()
                .With(x => x.Id, 1)
                .With(x => x.Username, createRequest.Username)
                .Create();
            _userService.CreateUserAsync(Arg.Any<CreateUserModel>()).Returns(createdUser);

            // Act
            var result = await _controller.CreateUser(createRequest);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserViewModel>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnedUser = Assert.IsType<UserViewModel>(createdResult.Value);
            Assert.Equal(createRequest.Username, returnedUser.Username);
        }

        [Fact]
        public async Task UpdateUser_WithMatchingId_ReturnsNoContent()
        {
            // Arrange
            var userId = 1;
            var updateRequest = _fixture.Build<UpdateUserRequest>()
                .With(x => x.Id, userId)
                .Create();
            _userService.UpdateUserAsync(Arg.Any<UpdateUserModel>()).Returns(true);

            // Act
            var result = await _controller.UpdateUser(userId, updateRequest);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateUser_WithMismatchedId_ReturnsBadRequest()
        {
            // Arrange
            var userId = 1;
            var updateRequest = _fixture.Build<UpdateUserRequest>()
                .With(x => x.Id, 2) // ID diferente
                .Create();

            // Act
            var result = await _controller.UpdateUser(userId, updateRequest);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateUser_WithNonExistingUser_ReturnsNotFound()
        {
            // Arrange
            var userId = 999;
            var updateRequest = _fixture.Build<UpdateUserRequest>()
                .With(x => x.Id, userId)
                .Create();
            _userService.UpdateUserAsync(Arg.Any<UpdateUserModel>()).Returns(false);

            // Act
            var result = await _controller.UpdateUser(userId, updateRequest);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteUser_WithExistingId_ReturnsNoContent()
        {
            // Arrange
            var userId = 1;
            _userService.DeleteUserAsync(userId).Returns(true);

            // Act
            var result = await _controller.DeleteUser(userId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteUser_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var userId = 999;
            _userService.DeleteUserAsync(userId).Returns(false);

            // Act
            var result = await _controller.DeleteUser(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
