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
    public class CustinfoesController : ControllerBase
    {
        private readonly BankingProjectContext _context;

        public CustinfoesController(BankingProjectContext context)
        {
            _context = context;
        }

        // GET: api/Custinfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Custinfo>>> GetCustinfo()
        {
            return await _context.Custinfo.ToListAsync();
        }

        // GET: api/Custinfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Custinfo>> GetCustinfo(int id)
        {
            var custinfo = await _context.Custinfo.FindAsync(id);

            if (custinfo == null)
            {
                return NotFound();
            }

            return custinfo;
        }

        // PUT: api/Custinfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustinfo(int id, Custinfo custinfo)
        {
            if (id != custinfo.Cid)
            {
                return BadRequest();
            }

            _context.Entry(custinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustinfoExists(id))
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

        // POST: api/Custinfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Custinfo>> PostCustinfo(Custinfo custinfo)
        {
            _context.Custinfo.Add(custinfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustinfo", new { id = custinfo.Cid }, custinfo);
        }

        // DELETE: api/Custinfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Custinfo>> DeleteCustinfo(int id)
        {
            var custinfo = await _context.Custinfo.FindAsync(id);
            if (custinfo == null)
            {
                return NotFound();
            }

            _context.Custinfo.Remove(custinfo);
            await _context.SaveChangesAsync();

            return custinfo;
        }

        private bool CustinfoExists(int id)
        {
            return _context.Custinfo.Any(e => e.Cid == id);
        }
    }
}
