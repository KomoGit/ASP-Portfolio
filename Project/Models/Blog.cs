using System.ComponentModel.DataAnnotations;

namespace AngerTravelTours.Models
{
    public class Blog:BaseEntities
    {
        public string Title { get; set; }
        public DateTime AddedDate { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
