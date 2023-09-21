using KanunWebsite.Models;
using KanunWebsite.Models.Blog;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminBlog:VMAdminBase
    {
        public List<Blog>? Blogs { get; set; }
    }

    public class VMAdminCreateBlog : VMAdminBase
    {
        #region Title
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250, ErrorMessage = "Cannot be more than 250")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
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
        public string? FullImage { get; set; } //For the page.
        [DataType(DataType.Upload)]
        public IFormFile? FullImageFile { get; set; }
        public string? PreviewImage { get; set; } //For the home page.
        [DataType(DataType.Upload)]
        public IFormFile? PreviewImageFile { get; set; }
        
        #endregion
        #region Metadata
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime PublishDate { get; set; } =  DateTime.Now;
        public bool IsHidden { get; set; } = false;
        #endregion
    }
    public class VMAdminEditBlog:VMAdminBase
    {
        
        #region Title
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250, ErrorMessage = "Cannot be more than 250")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
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
        public string? FullImage { get; set; } //For the page.
        [DataType(DataType.Upload)]
        public IFormFile? FullImageFile { get; set; }
        public string? PreviewImage { get; set; } //For the home page.
        [DataType(DataType.Upload)]
        public IFormFile? PreviewImageFile { get; set; }
        #endregion
        #region Metadata
        public Blog? CurrentBlogIteration { get; set; }
        public int CategoryId { get; set; }
        public bool IsHidden { get; set; } = false;
        #endregion

    }
}
