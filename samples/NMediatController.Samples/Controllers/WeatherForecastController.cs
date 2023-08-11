using MediatR;
using Microsoft.AspNetCore.Mvc;
using NMediatController.ASPNET;
using NMediatController.Samples.Handlers.GetWeatherForecast;

namespace NMediatController.Samples.Controllers
{
    /// <summary>
    /// Controller for weather updates.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseMediatController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of Mediator.</param>
        public WeatherForecastController(IMediator mediator)
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
            return Ok(await _mediator.Send(new GetWeatherForecastRequest()));
        }
    }
}