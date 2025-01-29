using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSphereAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSphereAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDiscussionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookDiscussionsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ 1️⃣ GET: api/bookdiscussions (Tüm Kitap Tartışmalarını Getir)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDiscussion>>> GetBookDiscussions()
        {
            return await _context.BookDiscussions.ToListAsync();
        }

        // ✅ 2️⃣ GET: api/bookdiscussions/{id} (Belirli Bir Kitap Tartışmasını Getir)
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDiscussion>> GetBookDiscussion(int id)
        {
            var discussion = await _context.BookDiscussions.FindAsync(id);
            if (discussion == null)
            {
                return NotFound();
            }
            return discussion;
        }

        // ✅ 3️⃣ POST: api/bookdiscussions (Yeni Kitap Tartışması Ekle)
        [HttpPost]
        public async Task<ActionResult<BookDiscussion>> PostBookDiscussion(BookDiscussion discussion)
        {
            _context.BookDiscussions.Add(discussion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookDiscussion), new { id = discussion.DiscussionId }, discussion);
        }

        // ✅ 4️⃣ PUT: api/bookdiscussions/{id} (Kitap Tartışmasını Güncelle)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDiscussion(int id, BookDiscussion discussion)
        {
            if (id != discussion.DiscussionId)
            {
                return BadRequest();
            }

            _context.Entry(discussion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ 5️⃣ DELETE: api/bookdiscussions/{id} (Kitap Tartışmasını Sil)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDiscussion(int id)
        {
            var discussion = await _context.BookDiscussions.FindAsync(id);
            if (discussion == null)
            {
                return NotFound();
            }

            _context.BookDiscussions.Remove(discussion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
