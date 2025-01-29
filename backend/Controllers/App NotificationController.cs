using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSphereAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSphereAPI.Controllers
{
    [Route("api/AppNotification")] // Route adını düzelttim
    [ApiController]
    public class AppNotificationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppNotificationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AppNotification (Tüm Bildirimleri Getir - Tarih sırasına göre)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppNotification>>> GetNotifications()
        {
            return await _context.AppNotifications
                .OrderByDescending(n => n.NotificationId) // En yeni bildirim en üstte
                .ToListAsync();
        }

        // GET: api/AppNotification/{id} (Belirli Bir Bildirimi Getir)
        [HttpGet("{id}")]
        public async Task<ActionResult<AppNotification>> GetNotification(int id)
        {
            var notification = await _context.AppNotifications.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }

        // POST: api/AppNotification (Yeni Bildirim Oluştur)
        [HttpPost]
        public async Task<ActionResult<AppNotification>> CreateNotification(AppNotification notification)
        {
            if (notification == null || string.IsNullOrWhiteSpace(notification.Message) || notification.UserId <= 0)
            {
                return BadRequest("Notification message and valid UserId are required.");
            }

            _context.AppNotifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
        }

        // DELETE: api/AppNotification/{id} (Belirli Bir Bildirimi Sil)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notification = await _context.AppNotifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.AppNotifications.Remove(notification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/AppNotification/User/{userId} (Belirli Kullanıcının Bildirimlerini Getir)
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<AppNotification>>> GetUserNotifications(int userId)
        {
            var userNotifications = await _context.AppNotifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.NotificationId) // En yeni bildirim en üstte
                .ToListAsync();

            return Ok(userNotifications); // Eğer yoksa 404 yerine boş liste döndürür
        }
    }
}
