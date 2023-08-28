using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KanunWebsite.Models
{
    public class FAQ : BaseModel
    {
        [Required]
        [Column("Question")]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10, ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Question { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Cannot exceed 250 letters.")]
        [MinLength(10,ErrorMessage = "Cannot be less than 10 letters.")]
        public string? Answer { get; set;}
        public bool IsHidden { get; set; } = false;
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(10,ErrorMessage = "Cannot exceed 10 letters.")]
        public string? CardId { get; set; } = GenerateCardId();


        private static string GenerateCardId()
        {
            Random random = new();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder idBuilder = new();

            idBuilder.Append(chars[random.Next(26)]);

            for (int i = 1; i != 10; i++)
            {
                idBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return idBuilder.ToString();
        }
    }
}
