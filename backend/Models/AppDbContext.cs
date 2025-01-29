using Microsoft.EntityFrameworkCore;

namespace BookSphereAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 📌 Tabloları temsil eden DbSet'ler
        public DbSet<User> Users { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDiscussion> BookDiscussions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<AppNotification> AppNotifications { get; set; }
        public DbSet<UserBookClubRelation> UserBookClubRelations { get; set; }
        public DbSet<EventUserRelation> EventUserRelations { get; set; }

        // 📌 Model Konfigürasyonu (İlişkiler, Anahtarlar ve Kısıtlamalar)
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // 1️⃣ UserBookClubRelation için Composite Key
    modelBuilder.Entity<UserBookClubRelation>()
        .HasKey(ubcr => new { ubcr.UserId, ubcr.BookClubId });

    // 2️⃣ EventUserRelation için Composite Key
    modelBuilder.Entity<EventUserRelation>()
        .HasKey(eur => new { eur.UserId, eur.EventId });

    // 3️⃣ AppNotification için Primary Key
    modelBuilder.Entity<AppNotification>()
        .HasKey(an => an.NotificationId);

    // 4️⃣ BookDiscussion için Primary Key
    modelBuilder.Entity<BookDiscussion>()
        .HasKey(bd => bd.DiscussionId);

    // 5️⃣ ✅ **Seed Data (Başlangıç Verileri)**
    modelBuilder.Entity<User>().HasData(
        new User { UserId = 1, UserName = "Admin", Email = "admin@example.com", HashedPassword = "hashedpassword123" },
        new User { UserId = 2, UserName = "User1", Email = "user1@example.com", HashedPassword = "user1hashedpassword" }
    );

    modelBuilder.Entity<BookClub>().HasData(
        new BookClub { BookClubId = 1, Name = "Classic Readers", Description = "A book club for classic literature enthusiasts", IsPublic = true }
    );

    // 🚀 **HATA VEREN KISIM DÜZELTİLDİ**
    modelBuilder.Entity<Book>().HasData(
        new
        {
            BookId = 1,
            Title = "1984",
            Author = "George Orwell",
            Genre = "Dystopian",
            BookClubId = 1 // ❌ `BookClub` yerine sadece Foreign Key `BookClubId` kullanıyoruz!
        },
        new
        {
            BookId = 2,
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            Genre = "Fiction",
            BookClubId = 1
        }
    );
}

    }
}
