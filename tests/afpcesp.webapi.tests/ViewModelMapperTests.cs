using AutoFixture;
using Xunit;
using afpcesp.application.Models;
using afpcesp.backoffice.webapi.Mappers;
using afpcesp.backoffice.webapi.ViewModel;

namespace afpcesp.webapi.tests
{
    public class ViewModelMapperTests
    {
        private readonly Fixture _fixture;

        public ViewModelMapperTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ToViewModel_WithValidUserModel_ReturnsUserViewModel()
        {
            // Arrange
            var model = _fixture.Build<UserModel>()
                .With(x => x.Id, 1)
                .With(x => x.Username, "testuser")
                .Create();

            // Act
            var result = ViewModelMapper.ToViewModel(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Username, result.Username);
            Assert.Equal(model.Username, result.Name);
        }

        [Fact]
        public void ToViewModel_WithNullModel_ThrowsArgumentNullException()
        {
            // Arrange
            UserModel? model = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ViewModelMapper.ToViewModel(model!));
        }

        [Fact]
        public void ToViewModelList_WithValidList_ReturnsViewModelList()
        {
            // Arrange
            var models = _fixture.CreateMany<UserModel>(3);

            // Act
            var result = ViewModelMapper.ToViewModelList(models);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void ToCreateModel_WithValidRequest_ReturnsCreateUserModel()
        {
            // Arrange
            var request = _fixture.Build<CreateUserRequest>()
                .With(x => x.Username, "newuser")
                .With(x => x.Password, "password123")
                .Create();

            // Act
            var result = ViewModelMapper.ToCreateModel(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Username, result.Username);
            Assert.Equal(request.Password, result.Password);
        }

        [Fact]
        public void ToCreateModel_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            CreateUserRequest? request = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ViewModelMapper.ToCreateModel(request!));
        }

        [Fact]
        public void ToUpdateModel_WithValidRequest_ReturnsUpdateUserModel()
        {
            // Arrange
            var request = _fixture.Build<UpdateUserRequest>()
                .With(x => x.Id, 1)
                .With(x => x.Username, "updateduser")
                .Create();

            // Act
            var result = ViewModelMapper.ToUpdateModel(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Id, result.Id);
            Assert.Equal(request.Username, result.Username);
        }

        [Fact]
        public void ToUpdateModel_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            UpdateUserRequest? request = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ViewModelMapper.ToUpdateModel(request!));
        }

        [Fact]
        public void ToLoginModel_WithValidRequest_ReturnsLoginModel()
        {
            // Arrange
            var request = _fixture.Build<LoginRequest>()
                .With(x => x.Username, "testuser")
                .With(x => x.Password, "password123")
                .Create();

            // Act
            var result = ViewModelMapper.ToLoginModel(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Username, result.Username);
            Assert.Equal(request.Password, result.Password);
        }

        [Fact]
        public void ToLoginModel_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            LoginRequest? request = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ViewModelMapper.ToLoginModel(request!));
        }

        [Fact]
        public void ToLoginResponse_WithValidModel_ReturnsLoginResponse()
        {
            // Arrange
            var model = _fixture.Build<AuthResponseModel>()
                .With(x => x.Token, "test-token")
                .With(x => x.Username, "testuser")
                .With(x => x.Email, "test@example.com")
                .Create();

            // Act
            var result = ViewModelMapper.ToLoginResponse(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Token, result.Token);
            Assert.Equal(model.Username, result.Username);
            Assert.Equal(model.Email, result.Email);
            Assert.Equal(model.ExpiresAt, result.ExpiresAt);
        }

        [Fact]
        public void ToLoginResponse_WithNullModel_ThrowsArgumentNullException()
        {
            // Arrange
            AuthResponseModel? model = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ViewModelMapper.ToLoginResponse(model!));
        }
    }
}
