namespace NMediatController.Samples.Handlers.GetWeatherForecast
{
    /// <summary>
    /// Response type for <see cref="GetWeatherForecastRequest"/>.
    /// </summary>
    public class GetWeatherForecastResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWeatherForecastResponse"/> class.
        /// </summary>
        public GetWeatherForecastResponse()
        {
            IsSuccess = true;
            StatusCode = ApplicationStatus.Success;
        }

        /// <summary>
        /// Gets or sets the weather result.
        /// </summary>
        public string Weather { get; set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether success flag.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a status code.
        /// </summary>
        public int StatusCode { get; }
    }
}
