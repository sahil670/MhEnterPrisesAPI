using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MhEnterPrises.Data;
using MhEnterPrises.Models;

namespace MhEnterPrises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAppliances1Controller : ControllerBase
    {
        private readonly MhEnterPrisesContext _context;

        public HomeAppliances1Controller(MhEnterPrisesContext context)
        {
            _context = context;
        }

        // GET: api/HomeAppliances1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeAppliances>>> GetHomeAppliances()
        {
            return await _context.HomeAppliances.ToListAsync();
        }

        // GET: api/HomeAppliances1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeAppliances>> GetHomeAppliances(int id)
        {
            var homeAppliances = await _context.HomeAppliances.FindAsync(id);

            if (homeAppliances == null)
            {
                return NotFound();
            }

            return homeAppliances;
        }

        // PUT: api/HomeAppliances1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeAppliances(int id, HomeAppliances homeAppliances)
        {
            if (id != homeAppliances.id)
            {
                return BadRequest();
            }

            _context.Entry(homeAppliances).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeAppliancesExists(id))
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

        // POST: api/HomeAppliances1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HomeAppliances>> PostHomeAppliances(HomeAppliances homeAppliances)
        {
            _context.HomeAppliances.Add(homeAppliances);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeAppliances", new { id = homeAppliances.id }, homeAppliances);
        }

        // DELETE: api/HomeAppliances1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HomeAppliances>> DeleteHomeAppliances(int id)
        {
            var homeAppliances = await _context.HomeAppliances.FindAsync(id);
            if (homeAppliances == null)
            {
                return NotFound();
            }

            _context.HomeAppliances.Remove(homeAppliances);
            await _context.SaveChangesAsync();

            return homeAppliances;
        }

        private bool HomeAppliancesExists(int id)
        {
            return _context.HomeAppliances.Any(e => e.id == id);
        }
    }
}
