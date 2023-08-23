using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediatorBuddy.Samples.Api.UpdateWeather
{
    /// <summary>
    /// Sample request.
    /// </summary>
    public class UpdateWeatherRequest : IEnvelopeRequest<UpdateWeatherResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWeatherRequest"/> class.
        /// </summary>
        /// <param name="value">The weather value.</param>
        [JsonConstructor]
        public UpdateWeatherRequest(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the updated weather value.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Value { get; }
    }
}
