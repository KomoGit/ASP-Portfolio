using KanunWebsite.Models;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminUser:VMAdminBase
    {
        public List<User>? Users { get; set; }
        public List<Title>? Titles { get; set; }
    }
}
