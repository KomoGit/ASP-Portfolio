using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
