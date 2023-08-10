using MediatR;

namespace NMediatController.Samples.Handlers.GetWeatherForecast
{
    /// <summary>
    /// A handler for the get weather forecast request.
    /// </summary>
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastRequest, GetWeatherForecastResponse>
    {
        /// <summary>
        /// A handler for the GetWeatherForecast request.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A response object for the request.</returns>
        public Task<GetWeatherForecastResponse> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetWeatherForecastResponse { Weather = "Hot, windy, humid, and rainy." });
        }
    }
}
