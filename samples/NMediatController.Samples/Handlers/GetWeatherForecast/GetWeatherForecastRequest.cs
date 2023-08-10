using MediatR;

namespace NMediatController.Samples.Handlers.GetWeatherForecast
{
    /// <summary>
    /// Request for a weather forecast.
    /// </summary>
    public class GetWeatherForecastRequest : IRequest<GetWeatherForecastResponse>
    {
    }
}
