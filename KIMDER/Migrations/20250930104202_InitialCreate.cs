using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KIMDER.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedDate", "Description", "EventDate", "ImageUrl", "IsActive", "Location", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), "Tüm mezunlarımızın bir araya geleceği muhteşem bir gece sizi bekliyor. Canlı müzik, yemek ve bol sohbet!", new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), "/images/mezunlar-gecesi.jpg", true, "Küçükköy AİHL Konferans Salonu", "Mezunlar Gecesi 2025" },
                    { 2, new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), "Mezunlarımız için düzenlenen piknik ve spor aktiviteleri ile keyifli bir gün geçireceğiz.", new DateTime(2025, 11, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "/images/piknik.jpg", true, "Atatürk Parkı", "Piknik ve Spor Şenliği" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, "Sevgili mezunlarımız, 15 Ekim 2025 tarihinde okulumuzda düzenlenecek olan mezunlar buluşmasına hepinizi davet ediyoruz. Eski günleri anımsayacak, yeni dostluklar kuracağımız bu özel günde sizleri aramızda görmekten mutluluk duyacağız.", new DateTime(2025, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), "/images/mezunlar-bulusma.jpg", true, "Mezunlar Buluşması 2025" },
                    { 2, "Küçükköy Anadolu İmam Hatip Lisesi olarak 25. yılımızı kutluyoruz! Bu gurur verici yıldönümünde tüm mezunlarımızı ve ailelerini kutlama etkinliğimize bekliyoruz.", new DateTime(2025, 9, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "/images/yildonumu.jpg", true, "Okul Yıldönümü Kutlaması" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
