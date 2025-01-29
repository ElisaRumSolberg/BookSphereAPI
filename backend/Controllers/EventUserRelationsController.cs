using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSphereAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSphereAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUserRelationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventUserRelationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventUserRelations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUserRelation>>> GetEventUserRelations()
        {
            return await _context.EventUserRelations.ToListAsync();
        }

        // GET: api/EventUserRelations/{userId}/{eventId}
        [HttpGet("{userId}/{eventId}")]
        public async Task<ActionResult<EventUserRelation>> GetEventUserRelation(int userId, int eventId)
        {
            var relation = await _context.EventUserRelations
                .FirstOrDefaultAsync(r => r.UserId == userId && r.EventId == eventId);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        // POST: api/EventUserRelations (Kullanıcı etkinliğe katılır)
        [HttpPost]
        public async Task<ActionResult<EventUserRelation>> CreateEventUserRelation(EventUserRelation relation)
        {
            _context.EventUserRelations.Add(relation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventUserRelation), new { userId = relation.UserId, eventId = relation.EventId }, relation);
        }

        // DELETE: api/EventUserRelations/{userId}/{eventId} (Kullanıcı etkinlikten ayrılır)
        [HttpDelete("{userId}/{eventId}")]
        public async Task<IActionResult> DeleteEventUserRelation(int userId, int eventId)
        {
            var relation = await _context.EventUserRelations
                .FirstOrDefaultAsync(r => r.UserId == userId && r.EventId == eventId);

            if (relation == null)
            {
                return NotFound();
            }

            _context.EventUserRelations.Remove(relation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
