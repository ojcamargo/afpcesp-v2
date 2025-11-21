using Microsoft.Extensions.Logging;
using afpcesp.application.Models;
using afpcesp.application.Mappers;
using afpcesp.dataaccess.models;
using afpcesp.dataaccess.repository;

namespace afpcesp.application.Services
{
    /// <summary>
    /// Serviço para gerenciamento de usuários na camada de aplicação.
    /// </summary>
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IBaseRepository<Usuario> _userRepository;
        private readonly ILogger<UserApplicationService> _logger;

        public UserApplicationService(IBaseRepository<Usuario> userRepository, ILogger<UserApplicationService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            try
            {
                var entities = await _userRepository.GetAllAsync();
                return UserMapper.ToModelList(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os usuários");
                throw;
            }
        }

        /// <summary>
        /// Obtém um usuário por ID.
        /// </summary>
        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            try
            {
                var entity = await _userRepository.GetByIdAsync(id);
                return entity != null ? UserMapper.ToModel(entity) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuário com ID {UserId}", id);
                throw;
            }
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        public async Task<UserModel> CreateUserAsync(CreateUserModel model)
        {
            try
            {
                var entity = UserMapper.ToEntity(model);
                var createdEntity = await _userRepository.AddAsync(entity);
                
                _logger.LogInformation("Usuário criado com sucesso: {UserId}", createdEntity.IdUsuario);
                
                return UserMapper.ToModel(createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário: {Username}", model.Username);
                throw;
            }
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        public async Task<bool> UpdateUserAsync(UpdateUserModel model)
        {
            try
            {
                var entity = await _userRepository.GetByIdAsync(model.Id);
                if (entity == null)
                {
                    _logger.LogWarning("Usuário não encontrado para atualização: {UserId}", model.Id);
                    return false;
                }

                UserMapper.UpdateEntity(entity, model);
                await _userRepository.UpdateAsync(entity);
                
                _logger.LogInformation("Usuário atualizado com sucesso: {UserId}", model.Id);
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário: {UserId}", model.Id);
                throw;
            }
        }

        /// <summary>
        /// Deleta um usuário por ID.
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var entity = await _userRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning("Usuário não encontrado para exclusão: {UserId}", id);
                    return false;
                }

                await _userRepository.DeleteAsync(id);
                _logger.LogInformation("Usuário deletado com sucesso: {UserId}", id);
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar usuário: {UserId}", id);
                throw;
            }
        }
    }
}
