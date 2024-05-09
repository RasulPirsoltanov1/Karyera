using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class HeaderVC : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
