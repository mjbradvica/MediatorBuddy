using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NMediatController.ASPNET
{
    /// <summary>
    /// A base class to use in for API controllers.
    /// </summary>
    public abstract class BaseMediatApiController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMediatApiController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        protected BaseMediatApiController(IMediator mediator)
        {
            Mediator = mediator;
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
        /// <returns>An IActionResult representing the end result of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<IEnvelope<TResponse>, IActionResult> responseFunc)
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
