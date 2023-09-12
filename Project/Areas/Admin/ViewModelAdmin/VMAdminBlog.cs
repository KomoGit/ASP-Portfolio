using KanunWebsite.Models.Blog;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminBlog:VMAdminBase
    {
        public List<Blog>? Blogs { get; set; }
    }

    public class VMAdminCreateBlog : VMAdminBase
    {

    }
}
