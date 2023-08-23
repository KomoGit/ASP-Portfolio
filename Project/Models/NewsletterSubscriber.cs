using System.ComponentModel.DataAnnotations;

namespace KanunWebsite.Models
{
    public class NewsletterSubscriber:BaseModel
    {
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime SubscriptionDate { get; set; } = DateTime.Now;     
    }
}
