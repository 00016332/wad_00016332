using KeyStoreAPI_00016332.Data;
using KeyStoreAPI_00016332.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyStoreAPI_00016332.Repositories
{
    // User Repository Pattern
    public class UserRepository: IRepository<User>
       
    {
        // Db Context
        private readonly GeneralDbContext _context;

        // Constructor
        public UserRepository(GeneralDbContext context)
        {
            _context = context;
        }

        // Creates User Entity
        public async Task CreateAsync(User entity)
        {
            await _context.UserDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        // Deletes User Entity
        public async Task DeleteAsync(int id)
        {
            var user = await _context.UserDbSet.FindAsync(id);
            if (user != null)
            {
                _context.UserDbSet.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        // Retrieves All Users 
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.UserDbSet.ToListAsync();
        }
        // Retrives User Entity by ID
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.UserDbSet.FindAsync(id);
        }
        // Updates User Entity
        public async Task UpdateAsync(User entity)
        {
            _context.UserDbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
