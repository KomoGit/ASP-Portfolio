using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class User : BaseModel
    {
        #region Basic Data
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(250, ErrorMessage = "Cannot be more than 250")]
        [MinLength(50, ErrorMessage = "Cannot be less than 50")]
        public string? FullName { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Biography { get; set; }
        [Required]
        public Title? UserTitle { get; set; }
        public int TitleId { get; set; }
        #region Images
        public string? BannerPicture { get; set; }
        public string? ProfilePicture { get; set; }

        #endregion
        #endregion
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
        #region Credentials
        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Email { get; set; }
        #endregion
    }
}
