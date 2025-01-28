namespace BookSphereAPI.Models
{
    public class BookClub
    {
        public int BookClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }

        // Navigasyon Özellikleri
        public ICollection<Book> Books { get; set; } // Book club içerisindeki kitaplar
        public ICollection<BookDiscussion> Discussions { get; set; } // Tartışmalar
        public ICollection<UserBookClubRelation> UserRelations { get; set; } // Book club ilişkileri
        public ICollection<Event> Events { get; set; } // Book club etkinlikleri
    }
}
