using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngerTravelTours.Models
{
    public class BaseEntities
    {
        [Key]
        public int Id { get; set; }
    }
}
