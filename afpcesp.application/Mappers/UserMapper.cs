using afpcesp.application.Models;
using afpcesp.dataaccess.models;

namespace afpcesp.application.Mappers
{
    /// <summary>
    /// Mapper para converter entre UserModel e Usuario (entidade do banco).
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Converte Usuario (entidade) para UserModel.
        /// </summary>
        public static UserModel ToModel(Usuario entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new UserModel
            {
                Id = entity.IdUsuario,
                Username = entity.DsLogin ?? string.Empty,
                Password = entity.DsSenha,
                IsActive = entity.FlAtivo ?? true,
                EmployeeId = entity.IdFuncionario
            };
        }

        /// <summary>
        /// Converte UserModel para Usuario (entidade).
        /// </summary>
        public static Usuario ToEntity(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Usuario
            {
                IdUsuario = model.Id,
                DsLogin = model.Username,
                DsSenha = model.Password,
                FlAtivo = model.IsActive,
                IdFuncionario = model.EmployeeId
            };
        }

        /// <summary>
        /// Converte CreateUserModel para Usuario (entidade).
        /// </summary>
        public static Usuario ToEntity(CreateUserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Usuario
            {
                DsLogin = model.Username,
                DsSenha = model.Password,
                FlAtivo = true,
                IdFuncionario = model.EmployeeId
            };
        }

        /// <summary>
        /// Atualiza uma entidade Usuario com dados de UpdateUserModel.
        /// </summary>
        public static void UpdateEntity(Usuario entity, UpdateUserModel model)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (model == null) throw new ArgumentNullException(nameof(model));

            entity.DsLogin = model.Username;
            if (model.IsActive.HasValue)
            {
                entity.FlAtivo = model.IsActive.Value;
            }
        }

        /// <summary>
        /// Converte lista de Usuario para lista de UserModel.
        /// </summary>
        public static IEnumerable<UserModel> ToModelList(IEnumerable<Usuario> entities)
        {
            return entities?.Select(ToModel) ?? Enumerable.Empty<UserModel>();
        }
    }
}
