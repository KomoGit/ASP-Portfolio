using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class NewsletterEmails
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
