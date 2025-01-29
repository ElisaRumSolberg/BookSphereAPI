using System;
using System.Collections.Generic;
using BookSphereAPI.Models;

namespace BookSphereAPI.Models
{
    public class Event
    {
        public int EventId { get; set; }

        // Varsayılan değer atandı
        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }

        // Varsayılan olarak boş bir liste atandı
        public ICollection<EventUserRelation> EventUserRelations { get; set; } = new List<EventUserRelation>();
    }
}
