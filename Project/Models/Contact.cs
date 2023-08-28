using System.ComponentModel.DataAnnotations;

namespace AngerTravelTours.Models
{
    public class Contact:BaseEntities
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage ="Duzgun mail daxil edin")]
        public string Email { get; set; }
    }
}
