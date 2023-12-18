// <copyright file="AcceptedResponses.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.AspNet.Responses
{
    /// <summary>
    /// Accepted responses.
    /// </summary>
    public static partial class ResponseOptions
    {
        /// <summary>
        /// Yields an empty <see cref="AcceptedResult"/>.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedEmpty<TResponse>()
        {
            return _ => new AcceptedResult();
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a static object as the value and a null location.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="response">A static response object.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(object response)
        {
            return _ => new AcceptedResult(null as string, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response as the value and a null location.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>()
        {
            return response => new AcceptedResult(null as string, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a response Func as the value and a null location.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="responseFunc">A func that will yield a response object.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, object> responseFunc)
        {
            return response => new AcceptedResult(null as string, responseFunc.Invoke(response));
        }

        /// <summary>
        /// Yields an empty <see cref="AcceptedResult"/> with a null value and string location.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="location">The <see cref="string"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedEmpty<TResponse>(string location)
        {
            return _ => new AcceptedResult(location, null);
        }

        /// <summary>
        /// Yield a <see cref="AcceptedResult"/> with a null value and location Func for the location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="locationFunc">A func that will yield the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedEmpty<TResponse>(Func<TResponse, string> locationFunc)
        {
            return response => new AcceptedResult(locationFunc.Invoke(response), null);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a static object for the value and string location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="string"/> with the location of the resource.</param>
        /// <param name="response">A static response object.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(string location, object response)
        {
            return _ => new AcceptedResult(location, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and string location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="string"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(string location)
        {
            return response => new AcceptedResult(location, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and location Func for the location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="locationFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="string"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, string> locationFunc)
        {
            return response => new AcceptedResult(locationFunc.Invoke(response), response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a Func for the value and location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> with will yield a <see cref="Tuple"/> with a location string and object.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, (string Location, object Result)> responseFunc)
        {
            return response =>
            {
                var (location, result) = responseFunc.Invoke(response);

                return new AcceptedResult(location, result);
            };
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a Func for the value and location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="Uri"/> with the location of the resource.</param>
        /// <returns>A function that will return an IActionResult of type AcceptedResult.</returns>
        public static Func<TResponse, IActionResult> AcceptedEmpty<TResponse>(Uri location)
        {
            return _ => new AcceptedResult(location, null);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and location Func for the location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="locationFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="Uri"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedEmpty<TResponse>(Func<TResponse, Uri> locationFunc)
        {
            return response => new AcceptedResult(locationFunc.Invoke(response), null);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a static <see cref="object"/> for the value and <see cref="Uri"/> location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="Uri"/> with the location of the resource.</param>
        /// <param name="response">A static response object.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Uri location, object response)
        {
            return _ => new AcceptedResult(location, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and <see cref="Uri"/> location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="location">A <see cref="Uri"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Uri location)
        {
            return response => new AcceptedResult(location, response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with the response for the value and location Func for the location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="locationFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="string"/> with the location of the resource.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, Uri> locationFunc)
        {
            return response => new AcceptedResult(locationFunc.Invoke(response), response);
        }

        /// <summary>
        /// Yields a <see cref="AcceptedResult"/> with a <see cref="Func{TResult}"/> for the value and location.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="responseFunc">A <see cref="Func{TResult}"/> with will yield a <see cref="Tuple"/> with a location <see cref="Uri"/> and <see cref="object"/>.</param>
        /// <returns>A <see cref="IActionResult"/> of type <see cref="AcceptedResult"/>.</returns>
        public static Func<TResponse, IActionResult> AcceptedResponse<TResponse>(Func<TResponse, (Uri Location, object Result)> responseFunc)
        {
            return response =>
            {
                var (location, result) = responseFunc.Invoke(response);

                return new AcceptedResult(location, result);
            };
        }
    }
}
