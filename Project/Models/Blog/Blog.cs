using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanunWebsite.Models.Blog
{
    public class Blog : BaseModel
    {
        #region Title
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(250, ErrorMessage = "Cannot be more than 250")]
        [MinLength(50, ErrorMessage = "Cannot be less than 50")]
        public string? Title { get; set; }
        #endregion
        #region Description
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Description { get; set; }
        #endregion
        #region BodyText
        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength(5000, ErrorMessage = "Cannot be more than 5000")]
        [MinLength(250, ErrorMessage = "Cannot be less than 250")]
        public string? BodyText { get; set; }
        #endregion
        #region Image
        [Required]
        public string? FullImage { get; set; } //For the page.
        [Required]
        public string? PreviewImage { get; set; } //For the home page.
        #endregion
        #region Metadata
        public int UserId { get; set; }
        public User? Publisher { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime PublishDate { get; set; }
        #endregion
    }
}
