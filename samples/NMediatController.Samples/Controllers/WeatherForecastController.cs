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
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of Mediator.</param>
        public WeatherForecastController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Gets the current weather forecast.
        /// </summary>
        /// <returns>An IActionResult with the weather.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetWeatherForecastRequest(), ResponseOptions.CreatedResponse("www.myUri.com"));
        }

        /// <summary>
        /// A controller action which uses a custom result func.
        /// </summary>
        /// <returns>An IActionResult with the weather.</returns>
        [HttpGet("special")]
        public async Task<IActionResult> SpecialGet()
        {
            return await ExecuteRequest(new GetWeatherForecastRequest(), MyCustomResult);
        }

        private IActionResult MyCustomResult(ApplicationResponse response)
        {
            return ResponseOptions.DetermineResponse(response.StatusCode, new NoContentResult(), i =>
            {
                return i switch
                {
                    999 => new BadRequestResult(),
                    _ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
                };
            });
        }
    }
}