// <copyright file="MediatorBuddyStandardPage.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// Base page for MediatorBuddy to simplify pages.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the viewModel.</typeparam>
    public abstract class MediatorBuddyStandardPage<TViewModel> : MediatorBuddyPage
        where TViewModel : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyStandardPage{TViewModel}"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="extraOptions">Any extra options to use for errors.</param>
        /// <param name="errorPage">The name of the error page if different from the default.</param>
        protected MediatorBuddyStandardPage(IMediator mediator, Func<RazorErrorWrapper, IActionResult?>? extraOptions = null, string errorPage = "/Error")
            : base(mediator, extraOptions, errorPage)
        {
            ViewModel = new TViewModel();
        }

        /// <summary>
        /// Gets or sets the viewModel.
        /// </summary>
        [BindProperty]
        public TViewModel ViewModel { get; set; }

        /// <summary>
        /// Executes the request and assigns it to the viewModel.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request to be executed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteQuery<TResponse>(IEnvelopeRequest<TResponse> request, CancellationToken cancellationToken = default)
            where TResponse : TViewModel
        {
            return await ExecuteRequest(request, response => ViewModel = response, cancellationToken);
        }

        /// <summary>
        /// Executes the request, maps the viewModel using the func and assigns it.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request to be processed.</param>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that accepts the response and returns the viewModel type.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteQuery<TResponse>(IEnvelopeRequest<TResponse> request, Func<TResponse, TViewModel> mappingFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, response => ViewModel = mappingFunc.Invoke(response), cancellationToken);
        }

        /// <summary>
        /// Executes the request and redirects to a page.
        /// </summary>
        /// <param name="request">The request to be processed.</param>
        /// <param name="pageName">The page name to redirect to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteCommand(IEnvelopeRequest request, string pageName, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.RedirectToPageResponse<Unit>(_ => (pageName, null, null)), cancellationToken);
        }

        /// <summary>
        /// Executes the request and redirects to a page.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request to be processed.</param>
        /// <param name="pageName">The page name to redirect to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteCommand<TResponse>(IEnvelopeRequest<TResponse> request, string pageName, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.RedirectToPageResponse<TResponse>(_ => (pageName, null, null)), cancellationToken);
        }

        /// <summary>
        /// Executes the request and redirects to a page.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request to be processed.</param>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> to define what page name to redirect to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        protected async Task<IActionResult> ExecuteCommand<TResponse>(IEnvelopeRequest<TResponse> request, Func<TResponse, (string? PageName, string? PageHandler, RouteValueDictionary? RouteValues)> resultFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteRequest(request, ResponseOptions.RedirectToPageResponse(resultFunc), cancellationToken);
        }
    }
}
