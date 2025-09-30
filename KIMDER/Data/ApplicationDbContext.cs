using Microsoft.EntityFrameworkCore;
using KucukkoyIHL.Models;

namespace KucukkoyIHL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Örnek veriler - Statik tarihler kullanılıyor
            modelBuilder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Title = "Mezunlar Buluşması 2025",
                    Content = "Sevgili mezunlarımız, 15 Ekim 2025 tarihinde okulumuzda düzenlenecek olan mezunlar buluşmasına hepinizi davet ediyoruz. Eski günleri anımsayacak, yeni dostluklar kuracağımız bu özel günde sizleri aramızda görmekten mutluluk duyacağız.",
                    ImageUrl = "/images/mezunlar-bulusma.jpg",
                    CreatedDate = new DateTime(2025, 9, 25, 10, 0, 0),
                    IsActive = true
                },
                new News
                {
                    Id = 2,
                    Title = "Okul Yıldönümü Kutlaması",
                    Content = "Küçükköy Anadolu İmam Hatip Lisesi olarak 25. yılımızı kutluyoruz! Bu gurur verici yıldönümünde tüm mezunlarımızı ve ailelerini kutlama etkinliğimize bekliyoruz.",
                    ImageUrl = "/images/yildonumu.jpg",
                    CreatedDate = new DateTime(2025, 9, 20, 14, 30, 0),
                    IsActive = true
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Mezunlar Gecesi 2025",
                    Description = "Tüm mezunlarımızın bir araya geleceği muhteşem bir gece sizi bekliyor. Canlı müzik, yemek ve bol sohbet!",
                    EventDate = new DateTime(2025, 10, 15, 19, 0, 0),
                    Location = "Küçükköy AİHL Konferans Salonu",
                    ImageUrl = "/images/mezunlar-gecesi.jpg",
                    CreatedDate = new DateTime(2025, 9, 25, 10, 0, 0),
                    IsActive = true
                },
                new Event
                {
                    Id = 2,
                    Title = "Piknik ve Spor Şenliği",
                    Description = "Mezunlarımız için düzenlenen piknik ve spor aktiviteleri ile keyifli bir gün geçireceğiz.",
                    EventDate = new DateTime(2025, 11, 5, 10, 0, 0),
                    Location = "Atatürk Parkı",
                    ImageUrl = "/images/piknik.jpg",
                    CreatedDate = new DateTime(2025, 9, 23, 9, 0, 0),
                    IsActive = true
                }
            );
        }
    }
}