namespace BookSphereAPI.Models
{
    public class UserBookClubRelation
    {
        public int UserId { get; set; }
        public int BookClubId { get; set; }
        public string Role { get; set; }

        // Navigasyon 
        public User User { get; set; }
        public BookClub BookClub { get; set; }
    }
}
