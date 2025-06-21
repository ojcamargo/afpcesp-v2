using afpcesp.dataaccess.models;
using afpcesp.dataaccess.repository;

namespace afpcesp.application.services
{
    /// <summary>
    /// Service class for managing user operations.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Repository for user operations.
        /// </summary>
        private readonly IBaseRepository<Usuario> _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The repository for user operations.</param>
        public UserService(IBaseRepository<Usuario> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retrieves all users asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Usuario>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Retrieves a user by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID.</returns>
        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adds a new user asynchronously.
        /// </summary>
        /// <param name="user">The user data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
        public async Task<Usuario> AddUserAsync(Usuario user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            return await _userRepository.AddAsync(user);
        }

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="user">The user data to update.</param>
        /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the user ID is not valid.</exception>
        public async Task UpdateUserAsync(Usuario user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            if (user.IdUsuario <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero");
            }

            await _userRepository.UpdateAsync(user);
        }

        /// <summary>
        /// Deletes a user by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}