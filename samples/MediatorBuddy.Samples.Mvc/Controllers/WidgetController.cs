// <copyright file="WidgetController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.AspNet.Responses;
using MediatorBuddy.Samples.Common.Features.AddWidget;
using MediatorBuddy.Samples.Common.Features.GetAll;
using MediatorBuddy.Samples.Common.Features.GetById;
using MediatorBuddy.Samples.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Mvc.Controllers
{
    /// <summary>
    /// Sample widget controller.
    /// </summary>
    [Route("[controller]")]
    public class WidgetController : BaseMvcController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="mapper">An instance of the <see cref="IMapper"/> interface.</param>
        public WidgetController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Sample widget index.
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
            return await ExecuteRequest(
                new GetWidgetByIdRequest(id),
                ResponseOptions.ViewResponse<GetWidgetByIdResponse, WidgetViewModel>(WidgetViewModel.FromWidget));
        }

        /// <summary>
        /// Get for add widget page.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Sample to add a widget.
        /// </summary>
        /// <param name="viewModel">The request object.</param>
        /// <returns>A <see cref="Task"/> of <see cref="IActionResult"/>.</returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddWidgetViewModel viewModel)
        {
            return await ExecuteRequest(
                new AddWidgetRequest(viewModel.Name),
                ResponseOptions.RedirectToActionResponse<AddWidgetResponse>(response => (
                    "Details",
                    "Widget",
                    new RouteValueDictionary(new { Id = response.Widget.Id }))));
        }
    }
}
