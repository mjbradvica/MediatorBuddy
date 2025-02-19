// <copyright file="AutoMappedWidgetController.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.Samples.Common.Features.AddWidget;
using MediatorBuddy.Samples.Common.Features.GetAll;
using MediatorBuddy.Samples.Common.Features.GetById;
using MediatorBuddy.Samples.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Mvc.Controllers
{
    /// <summary>
    /// Sample controller with auto mapped endpoints.
    /// </summary>
    [Route("[controller]")]
    public class AutoMappedWidgetController : BaseAutoMapperController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMappedWidgetController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="mapper">An instance of the <see cref="IMapper"/> interface.</param>
        public AutoMappedWidgetController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Gets all Widgets that currently exist.
        /// </summary>
        /// <returns>A <see cref="Task"/> of <see cref="IActionResult"/>.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await ExecuteGet<GetAllWidgetsResponse, WidgetIndexViewModel>(new GetAllWidgetsRequest());
        }

        /// <summary>
        /// Sample get by Id.
        /// </summary>
        /// <param name="id">A widget identifier.</param>
        /// <returns>A <see cref="Task"/> of <see cref="IActionResult"/>.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            return await ExecuteGet<GetWidgetByIdResponse, WidgetViewModel>(new GetWidgetByIdRequest(id));
        }

        /// <summary>
        /// Get for add widget page.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        /// <summary>
        /// Sample to add a widget.
        /// </summary>
        /// <param name="viewModel">The request object.</param>
        /// <returns>A <see cref="Task"/> of <see cref="IActionResult"/>.</returns>
        public async Task<IActionResult> Add(AddWidgetViewModel viewModel)
        {
            return await ExecutePost<AddWidgetViewModel, AddWidgetRequest, AddWidgetResponse>(
                viewModel,
                response => ("Details", "AutoMappedWidget", new RouteValueDictionary(new { Id = response.Widget.Id })));
        }
    }
}
