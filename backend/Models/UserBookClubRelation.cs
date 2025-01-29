using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class UserBookClubRelation
    {
        public int UserId { get; set; }
        public int BookClubId { get; set; }

        // Varsayılan değer atandı
        public string Role { get; set; } = string.Empty;

        // Navigation Property'lere varsayılan nesne atandı
        public User User { get; set; } = new User();
        public BookClub BookClub { get; set; } = new BookClub();
    }
}
