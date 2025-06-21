using System.Linq.Expressions;

namespace afpcesp.dataaccess.repository;

/// <summary>
/// Base repository interface for CRUD operations.
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface IBaseRepository<T>
{
    /// <summary>
    /// Retrieves all entities of type T asynchronously.
    /// </summary>
    /// <returns>List of entity type</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Retrieves an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">entity identifier</param>
    /// <returns>single entity</returns>
    Task<T> GetByIdAsync(int id);
    /// <summary>
    /// Finds entities based on a predicate asynchronously.
    /// </summary>
    /// <param name="predicate">Expression to filter entities</param>
    /// <returns>List of entities matching the predicate</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Count the number of entities of type T asynchronously.
    /// </summary>
    /// <param name="predicate">predicate</param>
    /// <returns>Number of ocurrences</returns>
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    /// <summary>
    /// Adds a new entity of type T asynchronously.
    /// </summary>
    /// <param name="entity">Entity type</param>
    /// <returns>Added entity</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity of type T asynchronously.
    /// </summary>
    /// <param name="entity">entity</param>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes an entity of type T by its identifier asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(int id);
}