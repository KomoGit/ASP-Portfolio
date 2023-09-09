using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Areas.Admin.ViewModel
{
    public class VMRegister
    {
        [Required(ErrorMessage = "Cannot be empty!")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250, ErrorMessage = "Cannot be more than 250")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email!")]
        [MaxLength(100, ErrorMessage = "Cannot be more than 100")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        [MaxLength(250,ErrorMessage = "Cannot be longer than 250")]
        [MinLength(6, ErrorMessage = "Cannot be less than 6")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Password confirm cannot be empty")]
        [MaxLength(250, ErrorMessage = "Cannot be longer than 250")]
        [MinLength(6, ErrorMessage = "Cannot be less than 6")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password and password confirm does not match!")]
        public string? PasswordConfirm { get; set; }
    }
}
