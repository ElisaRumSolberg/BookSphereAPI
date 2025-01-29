using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSphereAPI.Models
{
    public class BookDiscussion
    {
        [Key]  // Primary Key olduğunu belirtiyoruz
        public int DiscussionId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public int BookClubId { get; set; }

        // Navigation Property
        public BookClub BookClub { get; set; } = new BookClub();
    }
}
