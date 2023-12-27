// <copyright file="MediatorBuddyMvc.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;


/* Unmerged change from project 'MediatorBuddy.AspNet (netstandard2.1)'
Before:
using MediatR;
After:
using MediatorBuddy;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Mvc;
using MediatR;
*/
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
            string errorAction = "Index",
            string errorController = "Error")
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
        /// <param name="responseFunc">A function that will accept a response object and return a web response.</param>
        /// <returns>An IActionResult representing the end result of the request object.</returns>
        protected async Task<IActionResult> ExecuteRequest<TResponse>(IRequest<IEnvelope<TResponse>> request, Func<TResponse, IActionResult> responseFunc)
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return View(request);
            }

            try
            {
                var result = await Mediator.Send(request);

                if (result.Status == ApplicationStatus.Success)
                {
                    return responseFunc.Invoke(result.Response);
                }

                var errorResult = _extraOptions?.Invoke(RazorErrorWrapper.Instantiate(result.Status, result.Title, result.Detail));

                return errorResult ?? View();
            }
            catch (Exception exception)
            {
                await Mediator.Publish(new GlobalExceptionOccurred(exception));

                return RedirectToAction(_errorAction, _errorController);
            }
        }
    }
}
