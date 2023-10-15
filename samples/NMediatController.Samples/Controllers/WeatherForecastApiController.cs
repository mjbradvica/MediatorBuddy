// <copyright file="WeatherForecastApiController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NMediatController.ASPNET;
using NMediatController.Samples.Handlers.GetCurrentTime;
using NMediatController.Samples.Handlers.GetWeatherForecast;

namespace NMediatController.Samples.Controllers
{
    /// <summary>
    /// Controller for weather updates.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastApiController : BaseMediatApiController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastApiController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of Mediator.</param>
        public WeatherForecastApiController(IMediator mediator)
            : base(mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the current weather forecast.
        /// </summary>
        /// <returns>An IActionResult with the weather.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetWeatherForecastRequest(), ResponseOptions.OkObjectResponse<GetWeatherForecastResponse>());
        }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> with the time.</returns>
        [HttpGet("time")]
        public async Task<IActionResult> GetTime()
        {
            return await ExecuteRequest(new GetTimeRequest(), ResponseOptions.OkObjectResponse<GetTimeResponse>());
        }
    }
}