// <copyright file="ViewResponses.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// View responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> EmptyViewResponse<TResponse>()
        {
            return (_, razorViewData) => new ViewResult
            {
                ViewName = null,
                ViewData = razorViewData.ViewData,
                TempData = razorViewData.TempData,
            };
        }

        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> ViewResponse<TResponse>()
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = response;

                return new ViewResult
                {
                    ViewName = null,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="viewName">An optional view name to provide.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> ViewResponse<TResponse>(string viewName)
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = response;

                return new ViewResult
                {
                    ViewName = viewName,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> ViewResponse<TResponse>(Func<TResponse, object> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = mappingFunc.Invoke(response);

                return new ViewResult
                {
                    ViewName = null,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TResult">The type after a mapping func.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> ViewResponse<TResponse, TResult>(Func<TResponse, TResult> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = mappingFunc.Invoke(response);

                return new ViewResult
                {
                    ViewName = null,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> ViewResponse<TResponse>(Func<TResponse, (object ViewModel, string ViewName)> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                var (viewModel, viewName) = mappingFunc.Invoke(response);

                razorViewData.ViewData.Model = viewModel;

                return new ViewResult
                {
                    ViewName = viewName,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="ViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TResult">The type after a mapping func.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="ViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> ViewResponse<TResponse, TResult>(Func<TResponse, (TResult ViewModel, string ViewName)> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                var (viewModel, viewName) = mappingFunc.Invoke(response);

                razorViewData.ViewData.Model = viewModel;

                return new ViewResult
                {
                    ViewName = viewName,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> EmptyPartialViewResponse<TResponse>()
        {
            return (_, razorViewData) => new PartialViewResult
            {
                ViewName = null,
                ViewData = razorViewData.ViewData,
                TempData = razorViewData.TempData,
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> PartialViewResponse<TResponse>()
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = response;

                return new PartialViewResult
                {
                    ViewName = null,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="viewName">An optional view name to provide.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> PartialViewResponse<TResponse>(string viewName)
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = response;

                return new PartialViewResult
                {
                    ViewName = viewName,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> PartialViewResponse<TResponse>(Func<TResponse, object> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = mappingFunc.Invoke(response);

                return new PartialViewResult
                {
                    ViewName = null,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TResult">The type after a mapping func.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> PartialViewResponse<TResponse, TResult>(Func<TResponse, TResult> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                razorViewData.ViewData.Model = mappingFunc.Invoke(response);

                return new PartialViewResult
                {
                    ViewName = null,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> PartialViewResponse<TResponse>(Func<TResponse, (object ViewModel, string ViewName)> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                var (viewModel, viewName) = mappingFunc.Invoke(response);

                razorViewData.ViewData.Model = viewModel;

                return new PartialViewResult
                {
                    ViewName = viewName,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }

        /// <summary>
        /// Yields a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TResult">The type after a mapping func.</typeparam>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that will map to a viewModel.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="PartialViewResult"/>.</returns>
        public static Func<TResponse, RazorViewData, IActionResult> PartialViewResponse<TResponse, TResult>(Func<TResponse, (TResult ViewModel, string ViewName)> mappingFunc)
        {
            return (response, razorViewData) =>
            {
                var (viewModel, viewName) = mappingFunc.Invoke(response);

                razorViewData.ViewData.Model = viewModel;

                return new PartialViewResult
                {
                    ViewName = viewName,
                    ViewData = razorViewData.ViewData,
                    TempData = razorViewData.TempData,
                };
            };
        }
    }
}
