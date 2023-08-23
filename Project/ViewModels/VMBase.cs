using KanunWebsite.Models;
using KanunWebsite.Models.Blog;

namespace KanunWebsite.ViewModels
{
    public class VMBase
    {
        public NewsletterSubscriber? Subscriber { get; set; }
        public List<Blog>? Blogs { get; set; }
        public List<Category>? Categories { get; set; }
        public List<User>? Users { get; set; }
        public List<Title>? Titles { get; set; }
        public List<ContactDetails>? SiteContactDetails { get; set; }
    }
}
