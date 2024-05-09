using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class AdminFooterVC:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
