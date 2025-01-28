namespace BookSphereAPI.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }

        // Foreign Key
        public int BookClubId { get; set; }
        
        // Navigasyon Özellikleri
        public BookClub BookClub { get; set; } // Etkinliğin ait olduğu book club
        public ICollection<EventUserRelation> UserRelations { get; set; } // Katılımcılar
    }
}
