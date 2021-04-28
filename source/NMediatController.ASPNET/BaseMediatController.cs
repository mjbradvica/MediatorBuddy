namespace NMediatController.ASPNET
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseMediatController : ControllerBase
    {
        protected BaseMediatController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        /// <summary>
        /// Creates an <see cref="AcceptedResult"/> object that produces an <see cref="StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">The request to be handled.</param>
        /// <returns>The created <see cref="AcceptedResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAccepted<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Accepted());
        }

        /// <summary>
        /// Creates an <see cref="AcceptedResult"/> object that produces an <see cref="StatusCodes.Status202Accepted"/> response with an object body.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">The request to be handled.</param>
        /// <returns>The created <see cref="AcceptedResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedObject<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Accepted(response));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedResult"/> object that produces an <see cref="StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">The request to be handled.</param>
        /// <param name="uri">The optional URI wht the location at which the status of requested content can be monitored. May be null.</param>
        /// <returns>The created <see cref="AcceptedResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAccepted<TResponse>(IRequest<TResponse> request, string uri)
        {
            return await Execute(request, response => Accepted(uri));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedResult"/> object that produces an <see cref="StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">The request to be handled.</param>
        /// <param name="uri">The optional URI wht the location at which the status of requested content can be monitored. May be null.</param>
        /// <returns>The created <see cref="AcceptedResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAccepted<TResponse>(IRequest<TResponse> request, Uri uri)
        {
            return await Execute(request, response => Accepted(uri));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedResult"/> object that produces an <see cref="StatusCodes.Status202Accepted"/> response with an object body.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">The request to be handled.</param>
        /// <param name="uri">The optional URI wht the location at which the status of requested content can be monitored. May be null.</param>
        /// <returns>The created <see cref="AcceptedResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedObject<TResponse>(IRequest<TResponse> request, string uri)
        {
            return await Execute(request, response => Accepted(uri, response));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedResult"/> object that produces an <see cref="StatusCodes.Status202Accepted"/> response with an object body.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">The request to be handled.</param>
        /// <param name="uri">The optional URI wht the location at which the status of requested content can be monitored. May be null.</param>
        /// <returns>The created <see cref="AcceptedResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedObject<TResponse>(IRequest<TResponse> request, Uri uri)
        {
            return await Execute(request, response => Accepted(uri, response));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtAction<TResponse>(IRequest<TResponse> request, string actionName)
        {
            return await Execute(request, response => AcceptedAtAction(actionName));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="StatusCodes.Status202Accepted"/> response with an object body.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtActionObject<TResponse>(IRequest<TResponse> request, string actionName)
        {
            return await Execute(request, response => AcceptedAtAction(actionName, response));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="controllerName">The name of the controller to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtAction<TResponse>(IRequest<TResponse> request, string actionName, string controllerName)
        {
            return await Execute(request, response => AcceptedAtAction(actionName, controllerName));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="StatusCodes.Status202Accepted"/> response with an object body.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtActionObject<TResponse>(IRequest<TResponse> request, string actionName, object routeValues)
        {
            return await Execute(request, response => AcceptedAtAction(actionName, routeValues, response));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="controllerName">The name of the controller to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtAction<TResponse>(IRequest<TResponse> request, string actionName, string controllerName, object routeValues)
        {
            return await Execute(request, response => AcceptedAtAction(actionName, controllerName, routeValues));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="StatusCodes.Status202Accepted"/> response with an object body.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="controllerName">The name of the controller to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtActionObject<TResponse>(IRequest<TResponse> request, string actionName, string controllerName, object routeValues)
        {
            return await Execute(request, response => AcceptedAtAction(actionName, controllerName, routeValues, response));
        }




        // Ok
        protected async Task<IActionResult> HandleOk<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Ok(response));
        }

        // Created
        protected async Task<IActionResult> HandleCreated<TResponse>(IRequest<TResponse> request, Uri uri)
        {
            return await Execute(request, response => Created(uri, response));
        }

        protected async Task<IActionResult> HandleCreated<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Created(string.Empty, response));
        }

        // NoContent
        protected async Task<IActionResult> HandleNoContent<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => NoContent());
        }

        protected async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> responseFunc)
        {
            IActionResult response;

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await Mediator.Send(request);

                response = responseFunc.Invoke(result);
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception));

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
