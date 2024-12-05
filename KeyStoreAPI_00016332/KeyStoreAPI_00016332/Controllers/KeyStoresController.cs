using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeyStoreAPI_00016332.Data;
using KeyStoreAPI_00016332.Models;

namespace KeyStoreAPI_00016332.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyStoresController : ControllerBase
    {
        private readonly GeneralDbContext _context;

        public KeyStoresController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: api/KeyStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeyStore>>> GetKeyStoreDbSet()
        {
            return await _context.KeyStoreDbSet.ToListAsync();
        }

        // GET: api/KeyStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyStore>> GetKeyStore(int id)
        {
            var keyStore = await _context.KeyStoreDbSet.FindAsync(id);

            if (keyStore == null)
            {
                return NotFound();
            }

            return keyStore;
        }

        // PUT: api/KeyStores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyStore(int id, KeyStore keyStore)
        {
            if (id != keyStore.Id)
            {
                return BadRequest();
            }

            _context.Entry(keyStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyStoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/KeyStores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KeyStore>> PostKeyStore(KeyStore keyStore)
        {
            _context.KeyStoreDbSet.Add(keyStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyStore", new { id = keyStore.Id }, keyStore);
        }

        // DELETE: api/KeyStores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyStore(int id)
        {
            var keyStore = await _context.KeyStoreDbSet.FindAsync(id);
            if (keyStore == null)
            {
                return NotFound();
            }

            _context.KeyStoreDbSet.Remove(keyStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeyStoreExists(int id)
        {
            return _context.KeyStoreDbSet.Any(e => e.Id == id);
        }
    }
}
