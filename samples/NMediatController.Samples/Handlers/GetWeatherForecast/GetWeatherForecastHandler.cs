using MediatR;

namespace NMediatController.Samples.Handlers.GetWeatherForecast
{
    /// <summary>
    /// A handler for the get weather forecast request.
    /// </summary>
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastRequest, Envelope<GetWeatherForecastResponse>>
    {
        /// <summary>
        /// A handler for the GetWeatherForecast request.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A response object for the request.</returns>
        public Task<Envelope<GetWeatherForecastResponse>> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Envelope<GetWeatherForecastResponse>.Success(new GetWeatherForecastResponse()));
        }
    }
}
