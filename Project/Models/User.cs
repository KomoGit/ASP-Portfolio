using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class User : BaseModel
    {
        #region Basic Data
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250, ErrorMessage = "Cannot be more than 250")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? FullName { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Biography { get; set; }
        public Title? UserTitle { get; set; }
        public int TitleId { get; set; }
        #region Images
        public string? BannerPicture { get; set; }
        public string? ProfilePicture { get; set; }

        #endregion
        #endregion
        #region Socials
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Twitter { get; set; } = "https://twitter.com";
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Facebook { get; set; } = "https://facebook.com";
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? LinkedIn { get; set; } = "https://linkedin.com";
        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Cannot be more than 300")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Instagram { get; set; } = "https://instagram.com";
        #endregion
        #region Credentials
        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Email { get; set; }
        [Required]
        [MaxLength(250,ErrorMessage = "Cannot be more than 250")]
        [MinLength(6,ErrorMessage = "Cannot be more than 250")]
        public string? Password { get; set; }
        public string? Token { get; set; }
        #endregion
        #region Security
        public int LoginFails { get; set; } = 0;
        #endregion
    }
}
