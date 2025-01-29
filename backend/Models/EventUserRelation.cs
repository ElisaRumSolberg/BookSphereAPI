using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class EventUserRelation
    {
        public int UserId { get; set; }

        // Navigation Property, boş bir nesneyle başlatıldı
        public User User { get; set; } = new User();

        public int EventId { get; set; }

        // Navigation Property, boş bir nesneyle başlatıldı
        public Event Event { get; set; } = new Event();

        // Nullable olarak işaretlenmiş property
        public string? Role { get; set; }
    }
}
