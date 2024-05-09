
using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.ViewComponents
{
    public class AdminMenuVC : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
