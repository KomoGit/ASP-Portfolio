using AngerTravelTours.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AngerTravelTours.Interfaces
{
    public interface INewsletterCreate
    {
        public IActionResult Create(VMBase sub);
    }
}
