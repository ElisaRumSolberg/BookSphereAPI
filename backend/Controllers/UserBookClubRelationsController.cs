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
    public class UserBookClubRelationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserBookClubRelationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserBookClubRelations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBookClubRelation>>> GetUserBookClubRelations()
        {
            return await _context.UserBookClubRelations.ToListAsync();
        }

        // GET: api/UserBookClubRelations/{userId}/{bookClubId}
        [HttpGet("{userId}/{bookClubId}")]
        public async Task<ActionResult<UserBookClubRelation>> GetUserBookClubRelation(int userId, int bookClubId)
        {
            var relation = await _context.UserBookClubRelations
                .FirstOrDefaultAsync(r => r.UserId == userId && r.BookClubId == bookClubId);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        // POST: api/UserBookClubRelations (Kullanıcı kitap kulübüne katılır)
        [HttpPost]
        public async Task<ActionResult<UserBookClubRelation>> CreateUserBookClubRelation(UserBookClubRelation relation)
        {
            _context.UserBookClubRelations.Add(relation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserBookClubRelation), new { userId = relation.UserId, bookClubId = relation.BookClubId }, relation);
        }

        // DELETE: api/UserBookClubRelations/{userId}/{bookClubId} (Kullanıcı kitap kulübünden ayrılır)
        [HttpDelete("{userId}/{bookClubId}")]
        public async Task<IActionResult> DeleteUserBookClubRelation(int userId, int bookClubId)
        {
            var relation = await _context.UserBookClubRelations
                .FirstOrDefaultAsync(r => r.UserId == userId && r.BookClubId == bookClubId);

            if (relation == null)
            {
                return NotFound();
            }

            _context.UserBookClubRelations.Remove(relation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
