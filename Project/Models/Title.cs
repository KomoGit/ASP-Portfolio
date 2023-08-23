using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class Title : BaseModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Cannot exceed 100.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10.")]
        public string? UserTitle { get; set; }
    }
}
