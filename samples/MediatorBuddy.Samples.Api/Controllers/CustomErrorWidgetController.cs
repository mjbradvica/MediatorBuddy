// <copyright file="CustomErrorWidgetController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.Samples.Api.CustomFaults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.Controllers
{
    /// <summary>
    /// Sample controller with custom errors.
    /// </summary>
    public class CustomErrorWidgetController : MediatorBuddyApi
    {
        private static readonly Func<ApiErrorWrapper, IActionResult?>? ExtraOptions = wrapper =>
        {
            return wrapper.Status switch
            {
                ApplicationStatus.AccountHasNotBeenVerified => new ObjectResult(
                    new ErrorResponse(wrapper.ErrorTypes.AccountHasNotBeenVerified, wrapper.Title, wrapper.Status, wrapper.Detail, wrapper.Instance)),
                ApplicationStatus.EmailIsAlreadyUsed => new BadRequestObjectResult(
                    new ErrorResponse(wrapper.ErrorTypes.EmailIsAlreadyUsed, wrapper.Title, wrapper.Status, wrapper.Detail, wrapper.Instance)),
                CustomApplicationStatus.NotEnoughSteam => new ObjectResult(
                    new ErrorResponse((wrapper.ErrorTypes as CustomErrorTypes)?.NotEnoughSteam ?? wrapper.ErrorTypes.General, wrapper.Title, wrapper.Status, wrapper.Detail, wrapper.Instance)),
                _ => null,
            };
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomErrorWidgetController"/> class.
        /// </summary>
        /// <param name="mediator">Instance.</param>
        public CustomErrorWidgetController(IMediator mediator)
            : base(mediator, new CustomErrorTypes(), ExtraOptions)
        {
        }
    }
}
