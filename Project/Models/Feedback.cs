using System.ComponentModel.DataAnnotations.Schema;

namespace AngerTravelTours.Models
{
    public class Feedback:BaseEntities
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
