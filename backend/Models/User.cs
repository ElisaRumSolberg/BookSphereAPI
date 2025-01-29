using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class User
    {
        public int UserId { get; set; }

        // Varsayılan değerler atandı
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;

        // Koleksiyonlara varsayılan olarak boş liste atandı
        public ICollection<UserBookClubRelation> UserBookClubs { get; set; } = new List<UserBookClubRelation>();
        public ICollection<EventUserRelation> EventUserRelations { get; set; } = new List<EventUserRelation>();
        public ICollection<AppNotification> Notifications { get; set; } = new List<AppNotification>(); // Kullanıcıya gönderilen bildirimler
    }
}
