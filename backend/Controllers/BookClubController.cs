using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSphereAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSphereAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookClubsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookClubsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ 1️⃣ GET: api/bookclubs (Tüm Kitap Kulüplerini Getir)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookClub>>> GetBookClubs()
        {
            return await _context.BookClubs.ToListAsync();
        }

        // ✅ 2️⃣ GET: api/bookclubs/{id} (Belirli Kitap Kulübünü Getir)
        [HttpGet("{id}")]
        public async Task<ActionResult<BookClub>> GetBookClub(int id)
        {
            var bookClub = await _context.BookClubs.FindAsync(id);
            if (bookClub == null)
            {
                return NotFound();
            }
            return bookClub;
        }

        // ✅ 3️⃣ POST: api/bookclubs (Yeni Kitap Kulübü Ekle)
        [HttpPost]
        public async Task<ActionResult<BookClub>> PostBookClub(BookClub bookClub)
        {
            _context.BookClubs.Add(bookClub);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookClub), new { id = bookClub.BookClubId }, bookClub);
        }

        // ✅ 4️⃣ PUT: api/bookclubs/{id} (Kitap Kulübü Güncelle)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookClub(int id, BookClub bookClub)
        {
            if (id != bookClub.BookClubId)
            {
                return BadRequest();
            }

            _context.Entry(bookClub).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ 5️⃣ DELETE: api/bookclubs/{id} (Kitap Kulübü Sil)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookClub(int id)
        {
            var bookClub = await _context.BookClubs.FindAsync(id);
            if (bookClub == null)
            {
                return NotFound();
            }

            _context.BookClubs.Remove(bookClub);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
