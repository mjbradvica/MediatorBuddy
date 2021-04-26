namespace NMediatController.ASPNET
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseMediatController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseMediatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Accepted
        protected async Task<IActionResult> HandleAccepted<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Accepted());
        }

        protected async Task<IActionResult> HandleAcceptedObject<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Accepted(response));
        }

        protected async Task<IActionResult> HandleAccepted<TResponse>(IRequest<TResponse> request, string uri)
        {
            return await Execute(request, response => Accepted(uri));
        }

        protected async Task<IActionResult> HandleAccepted<TResponse>(IRequest<TResponse> request, Uri uri)
        {
            return await Execute(request, response => Accepted(uri));
        }

        protected async Task<IActionResult> HandleAcceptedObject<TResponse>(IRequest<TResponse> request, string uri)
        {
            return await Execute(request, response => Accepted(uri, response));
        }

        protected async Task<IActionResult> HandleAcceptedObject<TResponse>(IRequest<TResponse> request, Uri uri)
        {
            return await Execute(request, response => Accepted(uri, response));
        }

        // Accepted At Action
        protected async Task<IActionResult> HandleAcceptedAtAction<TResponse>(IRequest<TResponse> request, string actionName)
        {
            return await Execute(request, response => AcceptedAtAction(actionName));
        }

        /// <summary>
        /// Creates an <see cref="AcceptedAtActionResult"/> object that produces a <see cref="Microsoft.AspNetCore.Http.StatusCodes.Status202Accepted"/> response.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <returns>The created <see cref="AcceptedAtActionResult"/> for the response.</returns>
        protected async Task<IActionResult> HandleAcceptedAtActionObject<TResponse>(IRequest<TResponse> request, string actionName)
        {
            return await Execute(request, response => AcceptedAtAction(actionName, response));
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

        private async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> responseFunc)
        {
            IActionResult response;

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await _mediator.Send(request);

                response = responseFunc.Invoke(result);
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new GlobalExceptionOccurred(exception));

                return BadRequest(exception.Message);
            }

            return response;
        }
    }
}
