using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngerTravelTours.Models
{
    public class Subscriber:BaseEntities
    {
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [MinLength(10,ErrorMessage = "Cannot be less than 10 characthers")]
        [MaxLength(300,ErrorMessage = "Cannot be more than 300 characthers")]
        public string? Email { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
