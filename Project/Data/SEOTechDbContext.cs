using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class SEOTechDbContext:DbContext
    {
        public SEOTechDbContext(DbContextOptions<SEOTechDbContext> options) :base(options)
        {
            
        }
        public DbSet<SiteInformation> SiteInformation { get; set; }
        public DbSet<NewsletterEmails> NewsletterEmails { get; set; }
    }
}
