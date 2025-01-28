namespace BookSphereAPI.Models
{
    public class BookClub
    {
        public int BookClubId { get; set; } // Benzersiz kimlik
        public string Name { get; set; } // Book club adı
        public string Description { get; set; } // Book club açıklaması
        public bool IsPublic { get; set; } // Herkese açık mı, özel mi
    }
}
