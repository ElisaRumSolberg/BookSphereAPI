namespace BookSphereAPI.Models
{
    public class User
    {
        public int UserId { get; set; } // Kullanıcının benzersiz kimliği
        public string UserName { get; set; } // Kullanıcı adı
        public string Email { get; set; } // Kullanıcı email adresi
        public string HashedPassword { get; set; } // Şifre (hashlenmiş)
    }
}
