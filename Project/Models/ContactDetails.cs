using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class ContactDetails : BaseModel
    {
        #region Socials
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Twitter { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Facebook { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? LinkedIn { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Instagram { get; set; }
        #endregion
        [Required]
        [EmailAddress]
        [MaxLength(250,ErrorMessage = "Cannot be more than 250 letters.")]
        [MinLength(20,ErrorMessage = "Cannot be less than 20 letters.")]
        public string? Email { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100 letters.")]
        [MinLength(20, ErrorMessage = "Cannot be less than 20 letters.")]
        public string? Address { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100 symbols.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 symbols.")]
        //This can also take in letters and symbols which is kinda bad.
        public string? PhoneNumber { get; set; }
    }
}
