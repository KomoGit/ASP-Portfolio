using KanunWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminTestimonial:VMAdminBase
    {
        public List<Testimonial> Testimonials { get; set; }
    }
    public class VMAdminCreateTestimonial:VMAdminBase
    {
        [Required]
        [MaxLength(120, ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(5, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Cannot exceed 30 letters.")]
        [MinLength(5, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Title { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(5, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Description { get; set; }
        public string? Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsHidden { get; set; } = false;
    }
    public class VMAdminEditTestimonial : VMAdminBase
    {
        [Required]
        [MaxLength(120, ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(5, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Cannot exceed 30 letters.")]
        [MinLength(5, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Title { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(5, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Description { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool IsHidden { get; set; } = false;
        public Testimonial? CurrentTestimonialIteration { get; set; }
    }
}
