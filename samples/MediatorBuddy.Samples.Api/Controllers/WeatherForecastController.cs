// <copyright file="WeatherForecastController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Attributes;
using MediatorBuddy.Samples.Api.GetWeather;
using MediatorBuddy.Samples.Api.UpdateWeather;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorBuddy.Samples.Api.Controllers
{
    /// <summary>
    /// Sample controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [MediatorBuddyError]
    [MediatorBuddyValidation]
    public class WeatherForecastController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="mediator">Instance.</param>
        public WeatherForecastController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Sample Action.
        /// </summary>
        /// <returns>Result.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetWeatherRequest(), ResponseOptions.OkObjectResponse<GetWeatherResponse>());
        }

        /// <summary>
        /// Posts an updated weather.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(UpdateWeatherRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.CreatedResponse<UpdateWeatherResponse>(response => new Uri($"WeatherForecast/{response.Id}", UriKind.Relative)));
        }
    }
}