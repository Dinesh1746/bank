using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank.Models;

namespace bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenificiariesController : ControllerBase
    {
        private readonly BankingProjectContext _context;

        public BenificiariesController(BankingProjectContext context)
        {
            _context = context;
        }

        // GET: api/Benificiaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Benificiary>>> GetBenificiary()
        {
            return await _context.Benificiary.ToListAsync();
        }

        // GET: api/Benificiaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Benificiary>> GetBenificiary(int id)
        {
            var benificiary = await _context.Benificiary.FindAsync(id);

            if (benificiary == null)
            {
                return NotFound();
            }

            return benificiary;
        }

        // PUT: api/Benificiaries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenificiary(int id, Benificiary benificiary)
        {
            if (id != benificiary.Benaccountno)
            {
                return BadRequest();
            }

            _context.Entry(benificiary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenificiaryExists(id))
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

        // POST: api/Benificiaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Benificiary>> PostBenificiary(Benificiary benificiary)
        {
            _context.Benificiary.Add(benificiary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BenificiaryExists(benificiary.Benaccountno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBenificiary", new { id = benificiary.Benaccountno }, benificiary);
        }

        // DELETE: api/Benificiaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Benificiary>> DeleteBenificiary(int id)
        {
            var benificiary = await _context.Benificiary.FindAsync(id);
            if (benificiary == null)
            {
                return NotFound();
            }

            _context.Benificiary.Remove(benificiary);
            await _context.SaveChangesAsync();

            return benificiary;
        }

        private bool BenificiaryExists(int id)
        {
            return _context.Benificiary.Any(e => e.Benaccountno == id);
        }
    }
}
