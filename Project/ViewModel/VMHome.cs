using AngerTravelTours.Models;

namespace AngerTravelTours.ViewModel
{
    public class VMHome:VMBase
    {
        public List<Gallery>? Galleries { get; set; }
        public List<TourPackage>? Packages { get; set; }
    }
}
