namespace BookSphereAPI.Models
{
    public class Book
    {
        public int BookId { get; set; } // Benzersiz kimlik
        public string Title { get; set; } // Kitap başlığı
        public string Author { get; set; } // Yazar adı
        public string Genre { get; set; } // Tür
        public int BookClubId { get; set; } // Book club ile ilişki
    }
}
