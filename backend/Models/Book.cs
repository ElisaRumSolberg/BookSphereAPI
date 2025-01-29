using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }

        // Varsayılan değerler atandı
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        // Foreign Key
        public int BookClubId { get; set; }

        // Navigation Property, boş bir nesneyle başlatıldı
        public BookClub BookClub { get; set; } = new BookClub();
    }
}
