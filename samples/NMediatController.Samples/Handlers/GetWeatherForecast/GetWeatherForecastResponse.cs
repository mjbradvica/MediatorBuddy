namespace NMediatController.Samples.Handlers.GetWeatherForecast
{
    /// <summary>
    /// Response type for <see cref="GetWeatherForecastRequest"/>.
    /// </summary>
    public class GetWeatherForecastResponse : ApplicationResponse
    {
        /// <summary>
        /// Gets or sets the weather result.
        /// </summary>
        public string Weather { get; set; } = string.Empty;
    }
}
