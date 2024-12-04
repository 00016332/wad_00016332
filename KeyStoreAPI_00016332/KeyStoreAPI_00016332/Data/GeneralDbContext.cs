using KeyStoreAPI_00016332.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyStoreAPI_00016332.Data
{
    public class GeneralDbContext: DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> o) : base(o) { }

        public DbSet<User> UserDbSet { get; set; }

        public DbSet<KeyStore> KeyStoreDbSet { get; set; }
    }
}
