using Microsoft.EntityFrameworkCore;

namespace BookSphereAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDiscussion> BookDiscussions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<AppNotification> AppNotifications { get; set; }
        public DbSet<UserBookClubRelation> UserBookClubRelations { get; set; }
        public DbSet<EventUserRelation> EventUserRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBookClubRelation>()
                .HasKey(ubcr => new { ubcr.UserId, ubcr.BookClubId });

            modelBuilder.Entity<EventUserRelation>()
                .HasKey(eur => new { eur.UserId, eur.EventId });
        }
    }
}
