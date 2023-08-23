using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanunWebsite.Models.Blog
{
    public class Category : BaseModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Cannot exceed 100 Letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 Letters.")]
        [Column(TypeName = "ntext")]
        public string? Name { get; set; }
    }
}
