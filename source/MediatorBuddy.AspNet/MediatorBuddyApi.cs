// <copyright file="MediatorBuddyApi.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A base class to use in for API controllers.
    /// </summary>
    public abstract class MediatorBuddyApi : ControllerBase
    {
        private readonly ErrorTypes _errorTypes;
        private readonly Func<int, IActionResult>? _extraOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyApi"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="errorTypes">An instance of ErrorTypes to overload any defaults.</param>
        /// <param name="extraOptions">Extra conditions for the controller to check against.</param>
        protected MediatorBuddyApi(
            IMediator mediator,
            ErrorTypes? errorTypes = null,
            Func<int, IActionResult>? extraOptions = null)
        {
            Mediator = mediator;
            _errorTypes = errorTypes ?? new ErrorTypes();
            _extraOptions = extraOptions;
        }

        /// <summary>
        /// Gets the <see cref="IMediator"/> instance to use for custom methods.
        /// </summary>
        protected IMediator Mediator { get; }

        /// <summary>
        /// Accepts a request and executes it alongside common tasks used in a web request pipeline.
        /// </summary>
        /// <typeparam name="TResponse">The response type being returned from the controller action.</typeparam>
        /// <param name="request">The request object being sent to the execution pipeline.</param>
        /// <param name="responseFunc">A function that will accepts a response object and return a web response.</param>
        /// <returns>An IActionResult representing the end successResult of the request object.</returns>
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, IActionResult> responseFunc)
        {
            IActionResult response;

            var currentRoute = new Uri(HttpContext.Request.Path.Value ?? _errorTypes.General.ToString(), UriKind.Relative);

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(ErrorResponse.ValidationError(_errorTypes.General, validationResult.Errors, currentRoute));
            }

            try
            {
                var result = await Mediator.Send(request);

                response = DetermineResponse(result, responseFunc.Invoke(result.Response), currentRoute, _extraOptions);
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception));

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalError(_errorTypes.General, currentRoute));
            }

            return response;
        }

        /// <summary>
        /// A function that accepts a StatusCode and Result object and returns the appropriate response.
        /// </summary>
        /// <param name="envelope">The resulting envelope from the handler.</param>
        /// <param name="successResult">The successResult object from a handler.</param>
        /// <param name="currentRoute">The current route as Uri or link to general errors.</param>
        /// <param name="additionalOptions">Any additional response actions that may be required.</param>
        /// <returns>An IActionResult with the appropriate response.</returns>
        private IActionResult DetermineResponse<TResponse>(IEnvelope<TResponse> envelope, IActionResult successResult, Uri currentRoute, Func<int, IActionResult>? additionalOptions = null)
        {
            if (additionalOptions != null)
            {
                return additionalOptions.Invoke(envelope.StatusCode);
            }

            return envelope.StatusCode switch
            {
                ApplicationStatus.Success => successResult,
                ApplicationStatus.UserNameAlreadyExists => new ConflictObjectResult(ErrorResponse.FromEnvelope(_errorTypes.Auth, envelope, currentRoute)),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
            };
        }
    }
}
