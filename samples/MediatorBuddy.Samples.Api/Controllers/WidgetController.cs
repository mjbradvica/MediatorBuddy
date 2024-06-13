// <copyright file="WidgetController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Attributes;
using MediatorBuddy.AspNet.Responses;
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
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpPost(Name = "AddWidget")]
        [ProducesResponseType(typeof(AddWidgetResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddWidget(AddWidgetRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.CreatedResponse<AddWidgetResponse>(response => new Uri($"Widget/{response.Widget.Id}", UriKind.Relative)));
        }

        /// <summary>
        /// Gets a widget by id.
        /// </summary>
        /// <param name="id">A <see cref="Guid"/> identifier.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpGet("{id:guid}", Name = "GetWidgetById")]
        [MediatorBuddy404ErrorResponse]
        [ProducesResponseType(typeof(GetWidgetByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWidgetById(Guid id)
        {
            return await ExecuteRequest(new GetWidgetByIdRequest(id), ResponseOptions.OkObjectResponse<GetWidgetByIdResponse>());
        }

        /// <summary>
        /// Gets all widgets.
        /// </summary>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpGet(Name = "GetAllWidgets")]
        [ProducesResponseType(typeof(GetAllWidgetsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWidgets()
        {
            return await ExecuteRequest(new GetAllWidgetsRequest(), ResponseOptions.OkObjectResponse<GetAllWidgetsResponse>());
        }

        /// <summary>
        /// Deletes a widget.
        /// </summary>
        /// <param name="request">A <see cref="DeleteWidgetRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpDelete(Name = "DeleteWidget")]
        [MediatorBuddy404ErrorResponse]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteWidget(DeleteWidgetRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.NoContentResponse<Unit>());
        }

        /// <summary>
        /// Updates a widget.
        /// </summary>
        /// <param name="request">A <see cref="UpdateWidgetRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [HttpPut(Name = "UpdateWidget")]
        [MediatorBuddy404ErrorResponse]
        [ProducesResponseType(typeof(UpdateWidgetResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateWidget(UpdateWidgetRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.OkObjectResponse<UpdateWidgetResponse>());
        }
    }
}