using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
