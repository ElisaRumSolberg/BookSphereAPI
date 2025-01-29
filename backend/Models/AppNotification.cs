using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class AppNotification
    {
        public int NotificationId { get; set; }

        // Varsayılan değer atandı
        public string Message { get; set; } = string.Empty;

        // Foreign Key
        public int UserId { get; set; }

        // Navigation Property, boş bir nesneyle başlatıldı
        public User User { get; set; } = new User();
    }
}
