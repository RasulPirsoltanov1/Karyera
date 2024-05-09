using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class AdminHeaderVC:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
