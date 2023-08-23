using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A base page to use in Razor Pages applications.
    /// </summary>
    public abstract class MediatorBuddyPage : PageModel
    {
        private readonly string _errorPage;

        private readonly Func<int, IActionResult>? _extraOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyPage"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="extraOptions">Additional error handling options.</param>
        /// <param name="errorPage">The name of the Page to redirect to on exception. Defaults to "Error".</param>
        protected MediatorBuddyPage(IMediator mediator, Func<int, IActionResult>? extraOptions = null,  string errorPage = "/Error")
        {
            Mediator = mediator;
            _extraOptions = extraOptions;
            _errorPage = errorPage;
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
                return Page();
            }

            try
            {
                var result = await Mediator.Send(request);

                response = responseFunc.Invoke(result);
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception));

                return RedirectToPage(_errorPage);
            }

            return response;
        }
    }
}
