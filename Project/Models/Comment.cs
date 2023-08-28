using System.ComponentModel.DataAnnotations.Schema;

namespace AngerTravelTours.Models
{
    public class Comment:BaseEntities
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int? CommentId { get; set; }
        [ForeignKey("CommentId")]
        public Comment ParentComment { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
