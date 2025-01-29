using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class BookClub
    {
        public int BookClubId { get; set; }

        // Non-nullable alanlara varsayılan değer atandı
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;

        public bool IsPublic { get; set; }

        // Koleksiyonlara boş bir liste atandı
        public ICollection<Book> Books { get; set; } = new List<Book>(); // Book club içerisindeki kitaplar
        public ICollection<BookDiscussion> Discussions { get; set; } = new List<BookDiscussion>(); // Tartışmalar
        public ICollection<UserBookClubRelation> UserRelations { get; set; } = new List<UserBookClubRelation>(); // Book club ilişkileri
        public ICollection<Event> Events { get; set; } = new List<Event>(); // Book club etkinlikleri
    }
}
