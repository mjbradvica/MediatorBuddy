// <copyright file="WidgetController.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Attributes;
using MediatorBuddy.Samples.Common.Features.AddWidget;
using MediatorBuddy.Samples.Common.Features.DeleteWidget;
using MediatorBuddy.Samples.Common.Features.GetAll;
using MediatorBuddy.Samples.Common.Features.GetById;
using MediatorBuddy.Samples.Common.Features.UpdateWidget;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.Controllers
{
    /// <summary>
    /// Sample controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WidgetController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetController"/> class.
        /// </summary>
        /// <param name="mediator">Instance.</param>
        public WidgetController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Adds a widget to the system.
        /// </summary>
        /// <param name="request">A <see cref="AddWidgetRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpPost(Name = "AddWidget")]
        [ProducesResponseType(typeof(AddWidgetResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddWidget(AddWidgetRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteCreated(request, response => new Uri($"Widget/{response.Widget.Id}", UriKind.Relative), cancellationToken);
        }

        /// <summary>
        /// Gets a widget by id.
        /// </summary>
        /// <param name="id">A <see cref="Guid"/> identifier.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpGet("{id:guid}", Name = "GetWidgetById")]
        [MediatorBuddy404ErrorResponse]
        [ProducesResponseType(typeof(GetWidgetByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWidgetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(new GetWidgetByIdRequest(id), cancellationToken);
        }

        /// <summary>
        /// Gets all widgets.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpGet(Name = "GetAllWidgets")]
        [ProducesResponseType(typeof(GetAllWidgetsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWidgets(CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(new GetAllWidgetsRequest(), cancellationToken);
        }

        /// <summary>
        /// Deletes a widget.
        /// </summary>
        /// <param name="request">A <see cref="DeleteWidgetRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpDelete(Name = "DeleteWidget")]
        [MediatorBuddy404ErrorResponse]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteWidget(DeleteWidgetRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteNoContent(request, cancellationToken);
        }

        /// <summary>
        /// Updates a widget.
        /// </summary>
        /// <param name="request">A <see cref="UpdateWidgetRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpPut(Name = "UpdateWidget")]
        [MediatorBuddy404ErrorResponse]
        [ProducesResponseType(typeof(UpdateWidgetResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateWidget(UpdateWidgetRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(request, cancellationToken);
        }
    }
}