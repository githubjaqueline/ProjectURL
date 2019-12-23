using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectURL.Data.Context;
using ProjectURL.Domain.Models;

namespace ProjectURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Urls1Controller : ControllerBase
    {
        private readonly ProjectURLContext _context;

        public Urls1Controller(ProjectURLContext context)
        {
            _context = context;
        }

        // GET: api/Urls1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Url>>> GetdbSetUrl()
        {
            return await _context.dbSetUrl.ToListAsync();
        }

        // GET: api/Urls1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Url>> GetUrl(Guid id)
        {
            var url = await _context.dbSetUrl.FindAsync(id);

            if (url == null)
            {
                return NotFound();
            }

            return url;
        }

        // PUT: api/Urls1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrl(Guid id, Url url)
        {
            if (id != url.Id)
            {
                return BadRequest();
            }

            _context.Entry(url).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlExists(id))
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

        // POST: api/Urls1
        [HttpPost]
        public async Task<ActionResult<Url>> PostUrl(Url url)
        {
            _context.dbSetUrl.Add(url);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrl", new { id = url.Id }, url);
        }

        // DELETE: api/Urls1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Url>> DeleteUrl(Guid id)
        {
            var url = await _context.dbSetUrl.FindAsync(id);
            if (url == null)
            {
                return NotFound();
            }

            _context.dbSetUrl.Remove(url);
            await _context.SaveChangesAsync();

            return url;
        }

        private bool UrlExists(Guid id)
        {
            return _context.dbSetUrl.Any(e => e.Id == id);
        }
    }
}
