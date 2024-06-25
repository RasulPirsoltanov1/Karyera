using Karyera.Application.Features.Companies.Commands.Create;
using Karyera.Application.Features.Companies.Commands.Delete;
using Karyera.Application.Features.Companies.Queries;
using Karyera.Application.Features.Companies.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var compaines = await _mediator.Send(new CompanyGetAllQueryRequest());
            return View(compaines);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateCommandRequest companyCreateCommandRequest)
        {
            var result = await _mediator.Send(companyCreateCommandRequest);
            if (!result)
            {
                return View(companyCreateCommandRequest);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new CompanyDeleteCommandRequest
            {
                CompanyId = id,
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
