using KanunWebsite.Models;

namespace KanunWebsite.ViewModels
{
    public class VMHome:VMBase
    {
        public List<Testimonial>? Testimonials { get; set; }
        public List<FAQ>? FAQs { get; set; }
    }
}
