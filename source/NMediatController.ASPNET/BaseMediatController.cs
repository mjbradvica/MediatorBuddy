using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NMediatController.ASPNET
{
    /// <summary>
    /// A base class that provides basic boilerplate for a web request.
    /// </summary>
    public abstract class BaseMediatController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMediatController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the Mediator object.</param>
        protected BaseMediatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Accepts a request and executes it alongside common tasks used in a web request pipeline.
        /// </summary>
        /// <typeparam name="TResponse">The response type being returned from the controller action.</typeparam>
        /// <param name="request">The request object being sent to the execution pipeline.</param>
        /// <param name="responseFunc">A function that will accepts a response object and return a web response.</param>
        /// <returns>An IActionResult representing the end result of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<Envelope<TResponse>> request, Func<Envelope<TResponse>, IActionResult> responseFunc)
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

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
