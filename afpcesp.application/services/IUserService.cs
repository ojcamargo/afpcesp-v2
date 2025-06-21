using afpcesp.dataaccess.models;

public interface IUserService
{
    /// <summary>
    /// Retrieves all users asynchronously.
    /// </summary>
    /// <returns>A collection of users.</returns>
    Task<IEnumerable<Usuario>> GetAllUsersAsync();

    /// <summary>
    /// Retrieves a user by their ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The user with the specified ID.</returns>
    Task<Usuario> GetUserByIdAsync(int id);

    /// <summary>
    /// Adds a new user asynchronously.
    /// </summary>
    /// <param name="user">The user data to add.</param>
    /// <returns>The added user.</returns>
    Task<Usuario> AddUserAsync(Usuario user);

    /// <summary>
    /// Updates an existing user asynchronously.
    /// </summary>
    /// <param name="user">The user data to update.</param>
    Task UpdateUserAsync(Usuario user);
    /// <summary>
    /// Deletes a user by their ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    Task DeleteUserAsync(int id);
}