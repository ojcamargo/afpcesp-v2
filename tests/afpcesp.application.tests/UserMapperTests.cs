using AutoFixture;
using Xunit;
using afpcesp.application.Mappers;
using afpcesp.application.Models;
using afpcesp.dataaccess.models;

namespace afpcesp.application.tests
{
    public class UserMapperTests
    {
        private readonly Fixture _fixture;

        public UserMapperTests()
        {
            _fixture = new Fixture();
            
            // Configurar AutoFixture para omitir recursão em entidades do EF
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void ToModel_WithValidEntity_ReturnsUserModel()
        {
            // Arrange
            var entity = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, 1)
                .With(x => x.DsLogin, "testuser")
                .With(x => x.FlAtivo, true)
                .Create();

            // Act
            var result = UserMapper.ToModel(entity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity.IdUsuario, result.Id);
            Assert.Equal(entity.DsLogin, result.Username);
            Assert.Equal(entity.FlAtivo, result.IsActive);
        }

        [Fact]
        public void ToModel_WithNullEntity_ThrowsArgumentNullException()
        {
            // Arrange
            Usuario? entity = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => UserMapper.ToModel(entity!));
        }

        [Fact]
        public void ToEntity_WithValidUserModel_ReturnsUsuario()
        {
            // Arrange
            var model = _fixture.Build<UserModel>()
                .With(x => x.Id, 1)
                .With(x => x.Username, "testuser")
                .With(x => x.IsActive, true)
                .Create();

            // Act
            var result = UserMapper.ToEntity(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Id, result.IdUsuario);
            Assert.Equal(model.Username, result.DsLogin);
            Assert.Equal(model.IsActive, result.FlAtivo);
        }

        [Fact]
        public void ToEntity_WithValidCreateUserModel_ReturnsUsuario()
        {
            // Arrange
            var model = _fixture.Build<CreateUserModel>()
                .With(x => x.Username, "newuser")
                .With(x => x.Password, "password123")
                .Create();

            // Act
            var result = UserMapper.ToEntity(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Username, result.DsLogin);
            Assert.Equal(model.Password, result.DsSenha);
            Assert.True(result.FlAtivo);
        }

        [Fact]
        public void ToEntity_WithNullUserModel_ThrowsArgumentNullException()
        {
            // Arrange
            UserModel? model = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => UserMapper.ToEntity(model!));
        }

        [Fact]
        public void ToEntity_WithNullCreateUserModel_ThrowsArgumentNullException()
        {
            // Arrange
            CreateUserModel? model = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => UserMapper.ToEntity(model!));
        }

        [Fact]
        public void UpdateEntity_WithValidData_UpdatesEntityProperties()
        {
            // Arrange
            var entity = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, 1)
                .With(x => x.DsLogin, "oldusername")
                .With(x => x.FlAtivo, true)
                .Create();

            var updateModel = _fixture.Build<UpdateUserModel>()
                .With(x => x.Id, 1)
                .With(x => x.Username, "newusername")
                .With(x => x.IsActive, false)
                .Create();

            // Act
            UserMapper.UpdateEntity(entity, updateModel);

            // Assert
            Assert.Equal(updateModel.Username, entity.DsLogin);
            Assert.Equal(updateModel.IsActive, entity.FlAtivo);
        }

        [Fact]
        public void UpdateEntity_WithNullEntity_ThrowsArgumentNullException()
        {
            // Arrange
            Usuario? entity = null;
            var updateModel = _fixture.Create<UpdateUserModel>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => UserMapper.UpdateEntity(entity!, updateModel));
        }

        [Fact]
        public void UpdateEntity_WithNullModel_ThrowsArgumentNullException()
        {
            // Arrange
            var entity = _fixture.Create<Usuario>();
            UpdateUserModel? updateModel = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => UserMapper.UpdateEntity(entity, updateModel!));
        }

        [Fact]
        public void ToModelList_WithValidEntityList_ReturnsUserModelList()
        {
            // Arrange
            var entities = _fixture.Build<Usuario>()
                .With(x => x.IdUsuario, 1)
                .CreateMany(3);

            // Act
            var result = UserMapper.ToModelList(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void ToModelList_WithNullList_ReturnsEmptyList()
        {
            // Arrange
            IEnumerable<Usuario>? entities = null;

            // Act
            var result = UserMapper.ToModelList(entities!);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
