using KanunWebsite.Models;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminNewsletter:VMAdminBase
    {
        public List<NewsletterSubscriber>? Subscribers { get; set; }
    }
}
