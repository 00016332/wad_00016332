using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeyStoreAPI_00016332.Data;
using KeyStoreAPI_00016332.Models;
using AutoMapper;
using KeyStoreAPI_00016332.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using KeyStoreAPI_00016332.DTOs;

namespace KeyStoreAPI_00016332.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyStoresController : ControllerBase
    {
        private readonly IRepository<KeyStore> _keyStoreRepository;
        private readonly IMapper _mapper;

        public KeyStoresController(IRepository<KeyStore> keyStoreRepository, IMapper mapper)
        {
            _keyStoreRepository = keyStoreRepository;
            _mapper = mapper;
        }

        // GET: api/KeyStores
        [HttpGet]
        [SwaggerResponse(200, "Returns All Keys", typeof(IEnumerable<KeyStoreDto>))]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult<IEnumerable<KeyStore>>> GetKeyStoreDbSet()
        {
            var keyStores = await _keyStoreRepository.GetAllAsync();
            var keyStoreDtos = _mapper.Map<IEnumerable<KeyStoreDto>>(keyStores);
            return Ok(keyStoreDtos);
        }

        // GET: api/KeyStores/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Returns KeyStore", typeof(KeyStoreDto))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult<KeyStore>> GetKeyStore(int id)
        {
            var keyStore = await _keyStoreRepository.GetByIdAsync(id);
            if (keyStore == null)
            {
                return NotFound();
            }

            var keyStoreDto = _mapper.Map<KeyStoreDto>(keyStore);
            return Ok(keyStoreDto);
        }

        // PUT: api/KeyStores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> PutKeyStore(int id, KeyStoreDto keyStoreDto)
        {
            if (id != keyStoreDto.Id)
            {
                return BadRequest();
            }

            var keyStore = _mapper.Map<KeyStore>(keyStoreDto);
            await _keyStoreRepository.UpdateAsync(keyStore);
            return NoContent();
        }

        // POST: api/KeyStores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [SwaggerResponse(201, "Returns KeyStore", typeof(KeyStoreDto))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult<KeyStore>> PostKeyStore(KeyStoreDto keyStoreDto)
        {
            var keyStore = _mapper.Map<KeyStore>(keyStoreDto);
            await _keyStoreRepository.CreateAsync(keyStore);
            var createdKeyStoreDto = _mapper.Map<KeyStoreDto>(keyStore);
            return CreatedAtAction(nameof(GetKeyStore), new { id = createdKeyStoreDto.Id }, createdKeyStoreDto);
        }

        // DELETE: api/KeyStores/5
        [HttpDelete("{id}")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> DeleteKeyStore(int id)
        {
            var keyStore = await _keyStoreRepository.GetByIdAsync(id);
            if (keyStore == null)
            {
                return NotFound();
            }

            await _keyStoreRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
