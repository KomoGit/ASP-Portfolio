using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    /// <summary>
    /// Not to be confused with contact details. Inquiry is user requests for contact.
    /// </summary>
    public class ContactInquiry : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Fullname { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Email { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "Cannot exceed 120 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Subject { get; set; }
        [Required]
        [MaxLength(500,ErrorMessage = "Cannot exceed 500 letters.")]
        [MinLength(50, ErrorMessage = "Cannot be less than 50 letters.")]
        public string? BodyText { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
