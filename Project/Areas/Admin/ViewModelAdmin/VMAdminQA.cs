using KanunWebsite.Models;
using KanunWebsite.ViewModels;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminQA:VMAdminBase
    {
        public List<FAQ>? Questions { get; set; }    
    }
}
