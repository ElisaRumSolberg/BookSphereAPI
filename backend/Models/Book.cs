namespace BookSphereAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        // Foreign Key
        public int BookClubId { get; set; }
        
        // Navigasyon Özelliği
        public BookClub BookClub { get; set; }
    }
}
