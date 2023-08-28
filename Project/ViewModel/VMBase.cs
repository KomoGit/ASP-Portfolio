using AngerTravelTours.Models;

namespace AngerTravelTours.ViewModel
{
    public class VMBase
    {
        public List<Blog>? RecentPosts { get; set; }
        public List<Partner>? Partners { get; set; }
        public List<Feedback>? Feedbacks { get; set; }
        public Subscriber? Subscriber { get; set; }
        public List<Social>? Socials { get; set; }
    }
}
