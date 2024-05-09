using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class UIJsVC : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
