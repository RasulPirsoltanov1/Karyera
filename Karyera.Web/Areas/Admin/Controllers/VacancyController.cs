using Karyera.Application.Abstractions;
using Karyera.Application.Features.Categories.Queries.GetAll;
using Karyera.Application.Features.Jobs.Commands;
using Karyera.Application.Features.Jobs.Queries;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VacancyController : Controller
    {
        IMediator _mediator;
        IDbContextManager<Job> _dbContextManager;

        public VacancyController(IMediator mediator, IDbContextManager<Job> dbContextManager)
        {
            _mediator = mediator;
            _dbContextManager = dbContextManager;
        }

        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            var jobs = await _mediator.Send(new JobGetAllQueryRequest { PageNumber = pageNumber ?? 1 });
            ViewBag.PageNumber = pageNumber;
            var totalJobs = _dbContextManager.Table.Count();
            ViewBag.TotalJobs = totalJobs;
            return View(jobs);
        }

        public async Task<IActionResult> Create()
        {
            List<Category> categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobCreateCommandRequest command)
        {
            List<Category> categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            command.Requirements = command?.Requirements[0]?.Split(',').ToList();
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

    }
}
