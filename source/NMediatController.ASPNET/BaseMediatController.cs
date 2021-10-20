namespace NMediatController.ASPNET
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseMediatController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseMediatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> responseFunc)
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
