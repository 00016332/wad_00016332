namespace KeyStoreAPI_00016332.Repositories
{
    
    /// Generic repository interface for managing CRUD operations.
    public interface IRepository<T>
    {

        /// Creates a new entity in the database.
        Task CreateAsync(T entity);

        
        /// Updates an existing entity in the database.
        Task UpdateAsync(T entity);

        
        /// Deletes an entity from the database by its ID.
        Task DeleteAsync(int id);

       
        /// Retrieves all entities from the database.
        Task<IEnumerable<T>> GetAllAsync();

        
        /// Retrieves an entity by its ID.
        Task<T> GetByIdAsync(int id);
    }
}
