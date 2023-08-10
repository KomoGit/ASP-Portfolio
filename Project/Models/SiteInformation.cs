using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class SiteInformation
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Input cannot be longer than 250 symbols.")]
        [MinLength(10,ErrorMessage = "Input cannot be less that 10 symbols.")]
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string YouTube { get; set; } = string.Empty;
    }
}
