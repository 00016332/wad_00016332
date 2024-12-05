using KeyStoreAPI_00016332.Data;
using KeyStoreAPI_00016332.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyStoreAPI_00016332.Repositories
{
    public class KeyStoreRepository: IRepository<KeyStore>
    {
        private readonly GeneralDbContext _context;

        // Constructor
        public KeyStoreRepository(GeneralDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(KeyStore entity)
        {
            await _context.KeyStoreDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var keyStore = await _context.KeyStoreDbSet.FindAsync(id);
            if (keyStore != null)
            {
                _context.KeyStoreDbSet.Remove(keyStore);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<KeyStore>> GetAllAsync()
        {
            return await _context.KeyStoreDbSet.Include(e => e.User).ToListAsync();
        }

        public async Task<KeyStore> GetByIdAsync(int id)
        {
            return await _context.KeyStoreDbSet.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(KeyStore entity)
        {
            _context.KeyStoreDbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
