// <copyright file="MediatorBuddyPage.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Threading;
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

        private readonly Func<RazorErrorWrapper, IActionResult?>? _extraOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyPage"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="extraOptions">Additional error handling options.</param>
        /// <param name="errorPage">The name of the Page to redirect to on exception. Defaults to "Error".</param>
        protected MediatorBuddyPage(IMediator mediator, Func<RazorErrorWrapper, IActionResult?>? extraOptions = null, string errorPage = "/Error")
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
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> that will accept a response object and return a <see cref="IActionResult"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the end result of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, IActionResult> responseFunc, CancellationToken cancellationToken = default)
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return Page();
            }

            try
            {
                var result = await Mediator.Send(request, cancellationToken);

                if (result.Status == ApplicationStatus.Success)
                {
                    return responseFunc.Invoke(result.Response);
                }

                var errorResult = _extraOptions?.Invoke(RazorErrorWrapper.Instantiate(result.Status, result.Title, result.Detail));

                return errorResult ?? Page();
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception), cancellationToken);

                return RedirectToPage(_errorPage);
            }
        }

        /// <summary>
        /// Accepts a request and executes it alongside common tasks used in a web request pipeline.
        /// </summary>
        /// <typeparam name="TResponse">The response type being returned from the controller action.</typeparam>
        /// <param name="request">The request object being sent to the execution pipeline.</param>
        /// <param name="resultAction">A <see cref="Action"/> that will accept a response object. Typically, to update a view model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the end result of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Action<TResponse> resultAction, CancellationToken cancellationToken = default)
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return Page();
            }

            try
            {
                var result = await Mediator.Send(request, cancellationToken);

                if (result.Status == ApplicationStatus.Success)
                {
                    resultAction.Invoke(result.Response);

                    return Page();
                }

                var errorResult = _extraOptions?.Invoke(RazorErrorWrapper.Instantiate(result.Status, result.Title, result.Detail));

                return errorResult ?? Page();
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception), cancellationToken);

                return RedirectToPage(_errorPage);
            }
        }
    }
}
