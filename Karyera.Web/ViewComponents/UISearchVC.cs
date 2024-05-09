using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class UISearchVC:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
