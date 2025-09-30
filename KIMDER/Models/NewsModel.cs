using System;
using System.ComponentModel.DataAnnotations;

namespace KucukkoyIHL.Models
{
    public class News
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Başlık zorunludur")]
        [StringLength(200)]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = "İçerik zorunludur")]
        public string? Content { get; set; }
        
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
    }
}