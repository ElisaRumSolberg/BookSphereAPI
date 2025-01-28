namespace BookSphereAPI.Models
{
    public class AppNotification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        
        // Navigasyon Özelliği
        public User User { get; set; }
    }
}
