namespace BookSphereAPI.Models
{
    public class BookDiscussion
    {
        public int DiscussionId { get; set; } // Benzersiz kimlik
        public string Title { get; set; }     // Tartışma başlığı
        public string Content { get; set; }  // Tartışma içeriği
        public int BookClubId { get; set; }  // İlgili kitap kulübü
    }
}
