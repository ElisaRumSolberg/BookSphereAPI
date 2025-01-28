namespace BookSphereAPI.Models
{
    public class BookDiscussion
    {
        public int DiscussionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // Foreign Key
        public int BookClubId { get; set; }
        
        // Navigasyon Özelliği
        public BookClub BookClub { get; set; }
    }
}
