using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanunWebsite.Models
{
    public class FAQ : BaseModel
    {
        [Required]
        [Column("Question")]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Question { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10,ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Answer { get; set;}
        public bool IsHidden { get; set; } = false;
        [Required]
        public Guid CardId { get; set; } = Guid.NewGuid();
    }
}
