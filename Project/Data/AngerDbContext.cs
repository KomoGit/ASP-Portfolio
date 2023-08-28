using AngerTravelTours.Models;
using Microsoft.EntityFrameworkCore;

namespace AngerTravelTours.Data
{
    public partial class AngerDbContext:DbContext
    {
        public AngerDbContext(DbContextOptions<AngerDbContext> options):base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ChooseUs> ChooseUs { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Subscriber> Subscribes { get; set; }
        public virtual DbSet<TourPackage> TourPackages { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Service> Services { get; set; }
    }
}
