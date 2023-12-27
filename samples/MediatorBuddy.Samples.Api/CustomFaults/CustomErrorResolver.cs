// <copyright file="CustomErrorResolver.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.CustomFaults
{
    /// <summary>
    /// Resolver for custom faults.
    /// </summary>
    public static class CustomErrorResolver
    {
        /// <summary>
        /// Custom fault responses.
        /// </summary>
        /// <param name="wrapper">The error wrapper.</param>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        public static IActionResult? ResolveFaults(CustomErrorWrapper wrapper)
        {
            var asCustom = wrapper.ErrorTypes as CustomErrorTypes;

            return wrapper.Status switch
            {
                CustomApplicationStatus.NotEnoughSteam => new ObjectResult(new ErrorResponse(
                    asCustom?.NotEnoughSteam!,
                    wrapper.Title,
                    StatusCodes.Status418ImATeapot,
                    wrapper.Detail,
                    wrapper.Instance))
                {
                    StatusCode = StatusCodes.Status418ImATeapot,
                },
                _ => null,
            };
        }
    }
}
