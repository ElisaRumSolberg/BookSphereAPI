using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSphereAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSphereAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ 1️⃣ GET: api/events (Tüm Etkinlikleri Getir)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // ✅ 2️⃣ GET: api/events/{id} (Belirli Etkinliği Getir)
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt == null)
            {
                return NotFound();
            }
            return evnt;
        }

        // ✅ 3️⃣ POST: api/events (Yeni Etkinlik Ekle)
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event evnt)
        {
            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = evnt.EventId }, evnt);
        }

        // ✅ 4️⃣ PUT: api/events/{id} (Etkinlik Güncelle)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event evnt)
        {
            if (id != evnt.EventId)
            {
                return BadRequest();
            }

            _context.Entry(evnt).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ 5️⃣ DELETE: api/events/{id} (Etkinlik Sil)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evnt);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
