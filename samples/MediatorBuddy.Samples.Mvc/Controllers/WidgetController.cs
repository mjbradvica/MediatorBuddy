// <copyright file="WidgetController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.Samples.Mvc.Features.GetAll;
using MediatorBuddy.Samples.Mvc.Features.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Mvc.Controllers
{
    /// <summary>
    /// Sample widget controller.
    /// </summary>
    [Route("[controller]")]
    public class WidgetController : MediatorBuddyMvc
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public WidgetController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Sample widget index.
        /// </summary>
        /// <returns>A <see cref="Task"/> of <see cref="IActionResult"/>.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await ExecuteRequest(new GetAllWidgetsRequest(), response => View(response.Widgets));
        }

        /// <summary>
        /// Sample get by Id.
        /// </summary>
        /// <param name="id">A widget identifier.</param>
        /// <returns>A <see cref="Task"/> of <see cref="IActionResult"/>.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            return await ExecuteRequest(new GetWidgetByIdRequest(id), response => View(response.Widget));
        }
    }
}
