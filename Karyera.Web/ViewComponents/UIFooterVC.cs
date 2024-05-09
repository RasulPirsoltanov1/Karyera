using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class UIFooterVC:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
