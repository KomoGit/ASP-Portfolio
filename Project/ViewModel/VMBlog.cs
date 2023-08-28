using AngerTravelTours.Models;

namespace AngerTravelTours.ViewModel
{
    public class VMBlog:VMBase
    {
        public Blog? Blog { get; set; }
        public List<Blog>? Blogs { get; set; }
        public List<Blog>? RelatedPosts { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
