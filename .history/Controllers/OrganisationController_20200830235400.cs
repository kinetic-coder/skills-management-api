using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skills_management_api.Models;

namespace skills_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly OrganisationContext _context;

        public OrganisationController(OrganisationContext context)
        {
            _context = context;
        }

        // GET: api/Organisation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organisation>>> GetOrganisationItems()
        {
            return await _context.OrganisationItems.ToListAsync();
        }

        // GET: api/Organisation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organisation>> GetOrganisation(int id)
        {
            var organisation = await _context.OrganisationItems.FindAsync(id);

            if (organisation == null)
            {
                return NotFound();
            }

            return organisation;
        }

        // PUT: api/Organisation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganisation(int id, Organisation organisation)
        {
            if (id != organisation.Id)
            {
                return BadRequest();
            }

            _context.Entry(organisation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(id))
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

        // POST: api/Organisation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organisation>> PostOrganisation(Organisation organisation)
        {
            _context.OrganisationItems.Add(organisation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrganisation), new { id = organisation.Id }, organisation);
        }

        // DELETE: api/Organisation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organisation>> DeleteOrganisation(int id)
        {
            var organisation = await _context.OrganisationItems.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }

            _context.OrganisationItems.Remove(organisation);
            await _context.SaveChangesAsync();

            return organisation;
        }

        private bool OrganisationExists(int id)
        {
            return _context.OrganisationItems.Any(e => e.Id == id);
        }
    }
}
