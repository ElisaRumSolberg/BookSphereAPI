namespace BookSphereAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        // Navigasyon Özellikleri
        public ICollection<UserBookClubRelation> BookClubRelations { get; set; } // Kullanıcının book club ilişkileri
        public ICollection<AppNotification> Notifications { get; set; } // Kullanıcıya gönderilen bildirimler
        public ICollection<EventUserRelation> EventRelations { get; set; } // Kullanıcının katıldığı etkinlikler
    }
}
