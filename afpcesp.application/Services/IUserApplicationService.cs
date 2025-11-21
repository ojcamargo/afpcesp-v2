using afpcesp.application.Models;

namespace afpcesp.application.Services
{
    /// <summary>
    /// Interface para serviços de gerenciamento de usuários na camada de aplicação.
    /// </summary>
    public interface IUserApplicationService
    {
        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        Task<IEnumerable<UserModel>> GetAllUsersAsync();

        /// <summary>
        /// Obtém um usuário por ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Usuário encontrado ou null.</returns>
        Task<UserModel?> GetUserByIdAsync(int id);

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="model">Dados do usuário a ser criado.</param>
        /// <returns>Usuário criado.</returns>
        Task<UserModel> CreateUserAsync(CreateUserModel model);

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="model">Dados do usuário a ser atualizado.</param>
        /// <returns>True se atualizado com sucesso, false caso contrário.</returns>
        Task<bool> UpdateUserAsync(UpdateUserModel model);

        /// <summary>
        /// Deleta um usuário por ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser deletado.</param>
        /// <returns>True se deletado com sucesso, false caso contrário.</returns>
        Task<bool> DeleteUserAsync(int id);
    }
}
