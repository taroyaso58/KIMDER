using System;
using System.ComponentModel.DataAnnotations;

namespace KucukkoyIHL.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Etkinlik adı zorunludur")]
        [StringLength(200)]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = "Açıklama zorunludur")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "Etkinlik tarihi zorunludur")]
        public DateTime EventDate { get; set; }
        
        [StringLength(200)]
        public string? Location { get; set; }
        
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
    }
}