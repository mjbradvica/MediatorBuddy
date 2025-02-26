﻿// <copyright file="MediatorBuddyMvc.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet
{
    /// <summary>
    /// A base controller to use for MVC controllers.
    /// </summary>
    public abstract class MediatorBuddyMvc : Controller
    {
        private readonly string _errorAction;

        private readonly string _errorController;

        private readonly Func<RazorErrorWrapper, IActionResult?>? _extraOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorBuddyMvc"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        /// <param name="extraOptions">A <see cref="Func{TResult}"/> that accepts a <see cref="RazorErrorWrapper"/> and returns a <see cref="IActionResult"/>.</param>
        /// <param name="errorAction">The default name of the error view action.</param>
        /// <param name="errorController">The default name of the error view controller.</param>
        protected MediatorBuddyMvc(
            IMediator mediator,
            Func<RazorErrorWrapper, IActionResult?>? extraOptions = null,
            string errorAction = "Error",
            string errorController = "Home")
        {
            Mediator = mediator;
            _extraOptions = extraOptions;
            _errorAction = errorAction;
            _errorController = errorController;
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
                return View(request);
            }

            try
            {
                var result = await Mediator.Send(request, cancellationToken);

                if (result.Status == ApplicationStatus.Success)
                {
                    return responseFunc.Invoke(result.Response);
                }

                var errorResult = _extraOptions?.Invoke(RazorErrorWrapper.Instantiate(result.Status, result.Title, result.Detail));

                return errorResult ?? View();
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception), cancellationToken);

                return RedirectToAction(_errorAction, _errorController);
            }
        }

        /// <summary>
        /// Accepts a request and executes it alongside common tasks used in a web request pipeline.
        /// </summary>
        /// <typeparam name="TResponse">The response type being returned from the controller action.</typeparam>
        /// <param name="request">The request object being sent to the execution pipeline.</param>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> that will accept a response object and <see cref="RazorViewData"/> and return a <see cref="IActionResult"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the end result of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, RazorViewData, IActionResult> responseFunc, CancellationToken cancellationToken = default)
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return View(request);
            }

            try
            {
                var result = await Mediator.Send(request, cancellationToken);

                if (result.Status == ApplicationStatus.Success)
                {
                    var razorViewData = RazorViewData.Initialize(TempData, ViewData);

                    return responseFunc.Invoke(result.Response, razorViewData);
                }

                var errorResult = _extraOptions?.Invoke(RazorErrorWrapper.Instantiate(result.Status, result.Title, result.Detail));

                return errorResult ?? View();
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception), cancellationToken);

                return RedirectToAction(_errorAction, _errorController);
            }
        }
    }
}
