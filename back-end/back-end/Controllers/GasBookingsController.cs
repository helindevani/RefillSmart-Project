using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.DatabaseContext;
using back_end.Domain.Entities;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GasBookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GasBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GasBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GasBooking>>> GetGasBookings()
        {
          if (_context.GasBookings == null)
          {
              return NotFound();
          }
            return await _context.GasBookings.ToListAsync();
        }

        // GET: api/GasBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GasBooking>> GetGasBooking(Guid id)
        {
          if (_context.GasBookings == null)
          {
              return NotFound();
          }
            var gasBooking = await _context.GasBookings.FindAsync(id);

            if (gasBooking == null)
            {
                return NotFound();
            }

            return gasBooking;
        }

        // PUT: api/GasBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGasBooking(Guid id, GasBooking gasBooking)
        {
            if (id != gasBooking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(gasBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GasBookingExists(id))
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

        // POST: api/GasBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GasBooking>> PostGasBooking(GasBooking gasBooking)
        {
          if (_context.GasBookings == null)
          {
              return Problem("Entity set 'ApplicationDbContext.GasBookings'  is null.");
          }
            _context.GasBookings.Add(gasBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGasBooking", new { id = gasBooking.BookingId }, gasBooking);
        }

        // DELETE: api/GasBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasBooking(Guid id)
        {
            if (_context.GasBookings == null)
            {
                return NotFound();
            }
            var gasBooking = await _context.GasBookings.FindAsync(id);
            if (gasBooking == null)
            {
                return NotFound();
            }

            _context.GasBookings.Remove(gasBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GasBookingExists(Guid id)
        {
            return (_context.GasBookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
