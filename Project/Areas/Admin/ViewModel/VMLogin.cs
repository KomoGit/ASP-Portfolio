using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Areas.Admin.ViewModel
{
    public class VMLogin
    {
        [Required(ErrorMessage = "Cannot be empty!")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
