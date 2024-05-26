using Karyera.Application.Features.Categories.Commands.Create;
using Karyera.Application.Features.Categories.Commands.Delete;
using Karyera.Application.Features.Categories.Queries.GetAll;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Karyera.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateCommandRequest categoryCreateCommandRequest)
        {
            ViewBag.Categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            var result = await _mediator.Send(categoryCreateCommandRequest);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _mediator.Send(new CategoryDeleteCommandRequest
            {
                CategoryId = Id,
            });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            if (id == 0 || id == null)
            {
                return BadRequest();
            }
            var category = await _mediator.Send(new CategoryGetByIdRequest
            {
                Id = id,
            });
            return View(new CategoryUpdateCommandRequest
            {
                Id =category.Id,
                SubCategoryId=category.ParentCategoryId,
                ImageUrl = category.ImageUrl,
                Name=category.Name,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateCommandRequest categoryUpdateCommandRequest)
        {
            ViewBag.Categories = await _mediator.Send(new CategoryGetAllQueryRequest());
            var result = await _mediator.Send(categoryUpdateCommandRequest);
            return RedirectToAction(nameof(Index));
        }


    }
}
