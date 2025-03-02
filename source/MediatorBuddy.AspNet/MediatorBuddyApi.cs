// <copyright file="MediatorBuddyApi.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Attributes;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A base class to use in for API controllers.
    /// </summary>
    [MediatorBuddy400ErrorResponse]
    [MediatorBuddy500ErrorResponse]
    public abstract class MediatorBuddyApi : ControllerBase
    {
        private readonly ErrorTypes _errorTypes;
        private readonly Func<ApiErrorWrapper, IActionResult?>? _extraOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyApi"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="errorTypes">An instance of ErrorTypes to overload any defaults.</param>
        /// <param name="extraOptions">Extra conditions for the controller to check against.</param>
        protected MediatorBuddyApi(
            IMediator mediator,
            ErrorTypes? errorTypes = null,
            Func<ApiErrorWrapper, IActionResult?>? extraOptions = null)
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
        /// <param name="responseFunc">A function that will accept a response object and return a web response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>An IActionResult representing the end successResult of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, IActionResult> responseFunc, CancellationToken cancellationToken = default)
        {
            IActionResult response;

            var currentRoute = new Uri(HttpContext.Request.Path.Value ?? _errorTypes.General.ToString(), UriKind.Relative);

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(ErrorResponse.ValidationError(_errorTypes.ValidationConstraintNotMet, validationResult.Errors, currentRoute));
            }

            try
            {
                var result = await Mediator.Send(request, cancellationToken);

                response = DetermineResponse(result, responseFunc.Invoke(result.Response), currentRoute, _extraOptions);
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception), cancellationToken);

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalError(_errorTypes.General, currentRoute));
            }

            return response;
        }

        /// <summary>
        /// Handles a request with a pre-defined OkObject response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">A <see cref="IRequest{TResponse}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteOkObject<TResponse>(IRequest<IEnvelope<TResponse>> request, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.OkObjectResponse<TResponse>(), cancellationToken);
        }

        /// <summary>
        /// Handles a request with a pre-defined AcceptedObject response with location Uri.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">A <see cref="IRequest{TResponse}"/> object.</param>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> to define a location <see cref="Uri"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteAcceptedObject<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, Uri> responseFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.AcceptedResponse(responseFunc), cancellationToken);
        }

        /// <summary>
        /// Handles a request with a pre-defined AcceptedObject response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">A <see cref="IRequest{TResponse}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteAcceptedObject<TResponse>(IRequest<IEnvelope<TResponse>> request,  CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.AcceptedResponse<TResponse>(), cancellationToken);
        }

        /// <summary>
        /// Handles a request with a pre-defined CreatedObject response with a location Uri.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">A <see cref="IRequest{TResponse}"/> object.</param>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> to define a location <see cref="Uri"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteCreatedObject<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, Uri> responseFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.CreatedResponse(responseFunc), cancellationToken);
        }

        /// <summary>
        /// Handles a request with a pre-defined CreatedObject response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">A <see cref="IRequest{TResponse}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteCreatedObject<TResponse>(IRequest<IEnvelope<TResponse>> request, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.CreatedResponse<TResponse>(), cancellationToken);
        }

        /// <summary>
        /// Handles a request with a pre-defined NoContent response.
        /// </summary>
        /// <param name="request">A <see cref="IRequest{TResponse}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteNoContent(IRequest<IEnvelope<Unit>> request, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.NoContentResponse<Unit>(), cancellationToken);
        }

        /// <summary>
        /// A function that accepts a Status and Result object and returns the appropriate response.
        /// </summary>
        /// <param name="envelope">The resulting envelope from the handler.</param>
        /// <param name="successResult">The successResult object from a handler.</param>
        /// <param name="currentRoute">The current route as Uri or link to general errors.</param>
        /// <param name="additionalOptions">Any additional response actions that may be required.</param>
        /// <returns>An IActionResult with the appropriate response.</returns>
        private IActionResult DetermineResponse<TResponse>(IEnvelope<TResponse> envelope, IActionResult successResult, Uri currentRoute, Func<ApiErrorWrapper, IActionResult?>? additionalOptions = null)
        {
            var result = additionalOptions?.Invoke(ApiErrorWrapper.Instantiate(envelope.Status, envelope.Title, envelope.Detail, currentRoute, _errorTypes));

            if (result != null)
            {
                return result;
            }

            return envelope.Status switch
            {
                ApplicationStatus.Success => successResult,
                ApplicationStatus.GeneralError => StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.FromEnvelope(_errorTypes.General, StatusCodes.Status500InternalServerError, envelope, currentRoute)),
                ApplicationStatus.OperationCouldNotBeCompleted => StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.FromEnvelope(_errorTypes.OperationCouldNotBeCompleted, StatusCodes.Status500InternalServerError, envelope, currentRoute)),
                ApplicationStatus.EntityWasNotFound => NotFound(ErrorResponse.FromEnvelope(_errorTypes.EntityWasNotFound, StatusCodes.Status404NotFound, envelope, currentRoute)),
                ApplicationStatus.ConflictWithOtherResource => Conflict(ErrorResponse.FromEnvelope(_errorTypes.ConflictWithOtherResource, StatusCodes.Status409Conflict, envelope, currentRoute)),
                ApplicationStatus.ValidationConstraintNotMet => BadRequest(ErrorResponse.FromEnvelope(_errorTypes.ValidationConstraintNotMet, StatusCodes.Status400BadRequest, envelope, currentRoute)),
                ApplicationStatus.PreConditionNotMet => BadRequest(ErrorResponse.FromEnvelope(_errorTypes.PreConditionNotMet, StatusCodes.Status400BadRequest, envelope, currentRoute)),
                ApplicationStatus.PostConditionNotMet => BadRequest(ErrorResponse.FromEnvelope(_errorTypes.PostConditionNotMet, StatusCodes.Status400BadRequest, envelope, currentRoute)),
                ApplicationStatus.CouldNotProcessRequest => UnprocessableEntity(ErrorResponse.FromEnvelope(_errorTypes.CouldNotProcessRequest, StatusCodes.Status422UnprocessableEntity, envelope, currentRoute)),
                ApplicationStatus.UserDoesNotExist => NotFound(ErrorResponse.FromEnvelope(_errorTypes.UserDoesNotExist, StatusCodes.Status404NotFound, envelope, currentRoute)),
                ApplicationStatus.UserCouldNotBeCreated => StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.FromEnvelope(_errorTypes.UserCouldNotBeCreated, StatusCodes.Status500InternalServerError, envelope, currentRoute)),
                ApplicationStatus.UsernameAlreadyExists => Conflict(ErrorResponse.FromEnvelope(_errorTypes.UsernameAlreadyExists, StatusCodes.Status409Conflict, envelope, currentRoute)),
                ApplicationStatus.EmailIsAlreadyUsed => Conflict(ErrorResponse.FromEnvelope(_errorTypes.EmailIsAlreadyUsed, StatusCodes.Status409Conflict, envelope, currentRoute)),
                ApplicationStatus.PasswordIsIncorrect => BadRequest(ErrorResponse.FromEnvelope(_errorTypes.PasswordIsIncorrect, StatusCodes.Status400BadRequest, envelope, currentRoute)),
                ApplicationStatus.PasswordDoesNotMeetRequirements => BadRequest(ErrorResponse.FromEnvelope(_errorTypes.PasswordDoesNotMeetRequirements, StatusCodes.Status400BadRequest, envelope, currentRoute)),
                ApplicationStatus.TooManyRecentAttempts => StatusCode(StatusCodes.Status429TooManyRequests, ErrorResponse.FromEnvelope(_errorTypes.TooManyRecentAttempts, StatusCodes.Status429TooManyRequests, envelope, currentRoute)),
                ApplicationStatus.AccountIsLockedOut => StatusCode(StatusCodes.Status423Locked, ErrorResponse.FromEnvelope(_errorTypes.AccountIsLockedOut, StatusCodes.Status423Locked, envelope, currentRoute)),
                ApplicationStatus.AccountHasNotBeenVerified => StatusCode(StatusCodes.Status403Forbidden, ErrorResponse.FromEnvelope(_errorTypes.AccountHasNotBeenVerified, StatusCodes.Status403Forbidden, envelope, currentRoute)),
                ApplicationStatus.EmailHasNotBeenVerified => StatusCode(StatusCodes.Status403Forbidden, ErrorResponse.FromEnvelope(_errorTypes.EmailHasNotBeenVerified, StatusCodes.Status403Forbidden, envelope, currentRoute)),
                ApplicationStatus.TwoFactorCodeIncorrect => BadRequest(ErrorResponse.FromEnvelope(_errorTypes.TwoFactorCodeIncorrect, StatusCodes.Status400BadRequest, envelope, currentRoute)),
                ApplicationStatus.UnauthorizedUser => Unauthorized(ErrorResponse.FromEnvelope(_errorTypes.UnauthorizedUser, StatusCodes.Status401Unauthorized, envelope, currentRoute)),
                ApplicationStatus.ContentIsForbidden => StatusCode(StatusCodes.Status403Forbidden, ErrorResponse.FromEnvelope(_errorTypes.ContentIsForbidden, StatusCodes.Status403Forbidden, envelope, currentRoute)),
                ApplicationStatus.GeneralAuthError => Unauthorized(ErrorResponse.FromEnvelope(_errorTypes.GeneralAuthError, StatusCodes.Status401Unauthorized, envelope, currentRoute)),
                ApplicationStatus.AuthenticationChallenged => Unauthorized(ErrorResponse.FromEnvelope(_errorTypes.AuthenticationChallenged, StatusCodes.Status401Unauthorized, envelope, currentRoute)),
                _ => StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalError(_errorTypes.General, currentRoute)),
            };
        }
    }
}
