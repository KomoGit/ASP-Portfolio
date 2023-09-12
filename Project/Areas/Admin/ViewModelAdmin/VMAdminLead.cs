using KanunWebsite.Models;

namespace KanunWebsite.Areas.Admin.ViewModelAdmin
{
    public class VMAdminLead:VMAdminBase
    {
        public List<ContactInquiry>? Leads { get; set; } 
    }
}
