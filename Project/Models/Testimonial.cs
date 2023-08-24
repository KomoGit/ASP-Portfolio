using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class Testimonial:BaseModel
    {
        [Required]
        [MaxLength(120,ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(10,ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Fullname { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Cannot exceed 30 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Title { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Description { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Image { get; set; }
    }
}
