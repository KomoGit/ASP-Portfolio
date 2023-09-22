using KanunWebsite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminQA:VMAdminBase
    {
        public List<FAQ>? Questions { get; set; }    
    }
    public class VMAdminCreateQA:VMAdminBase 
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Question { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Answer { get; set; }
        public bool IsHidden { get; set; } = false;
        [Required]
        [MaxLength(10, ErrorMessage = "Cannot exceed 10 letters.")]
        public string? CardId { get; set; }
    }
    public class VMAdminEditQA:VMAdminBase
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Question { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Answer { get; set; }
        public bool IsHidden { get; set; } = false;
        [Required]
        [MaxLength(10, ErrorMessage = "Cannot exceed 10 letters.")]
        public string? CardId { get; set; }
    }
}
