using KanunWebsite.Models;
using KanunWebsite.Models.Blog;
using Microsoft.EntityFrameworkCore;

namespace KanunWebsite.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Title>? Titles { get; set; }
        public DbSet<NewsletterSubscriber>? Subscribers { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Category>? Categories { get; set; }        
        public DbSet<ContactDetails>? ContactDetails { get; set; }        
    }
}
