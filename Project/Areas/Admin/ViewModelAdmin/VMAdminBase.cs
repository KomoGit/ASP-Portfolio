using KanunWebsite.Models.Blog;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminBase
    {
        public string? Fullname { get; set; }
        public string? ProfileImage { get; set; }
        public string? Token { get; set; }
        public string? Email { get; set; }
        public List<Category>? Categories { get; set; }
        //public Blog? NewBlogContent { get; set; }
    }
}
