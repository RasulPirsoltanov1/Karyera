using Karyera.Application.Abstractions;
using Karyera.Application.Features.Categories.Queries.GetAll;
using Karyera.Application.Features.Jobs.Commands.Create;
using Karyera.Application.Features.Jobs.Commands.Delete;
using Karyera.Application.Features.Jobs.Commands.Update;
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
        public async Task<IActionResult> Delete(int id, int? pageNum = 1)
        {
            var result = await _mediator.Send(new JobDeleteCommandRequest()
            {
                JobId = id
            });
            return RedirectToAction(nameof(Index), new { pageNumber = pageNum });
        }

        public async Task<IActionResult> Update(int id)
        {
            List<Category> categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            ViewBag.Categories = categories;
            var job = await _mediator.Send(new JobGetByIdQueryRequest
            {
                JobId = id
            });
            if (job == null)
            {
                return BadRequest();
            }
            return View(new JobUpdateCommandRequest
            {
                Company = job.Company,
                CategoryId = job.CategoryId,
                ContactEmail = job.ContactEmail,
                Description = job.Description,
                EndDate = job.EndDate,
                Id = job.Id,
                IsRemote = job?.IsRemote ?? false,
                Location = job.Location,
                Requirements = job.Requirements,
                Salary = job.Salary,
                Title = job.Title
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(JobUpdateCommandRequest jobUpdateCommandRequest)
        {
            List<Category> categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            ViewBag.Categories = categories;
            var result = await _mediator.Send(jobUpdateCommandRequest);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(jobUpdateCommandRequest);
        }
        public async Task<IActionResult> Details(int id)
        {
            var job = await _mediator.Send(new JobGetByIdQueryRequest
            {
                JobId = id,
            });
            if (job == null)
                return BadRequest();
            return View(job);
        }
    }
}
