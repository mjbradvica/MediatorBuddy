using System.Text.Json.Serialization;

namespace NMediatController
{
    /// <summary>
    /// The base class for a MediatR response object that contains metadata about an application status.
    /// </summary>
    public abstract class ApplicationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResponse"/> class indicating success.
        /// </summary>
        protected ApplicationResponse()
        {
            IsSuccess = true;
            StatusCode = ApplicationStatus.Success;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResponse"/> class.
        /// </summary>
        /// <param name="statusCode">A status code indicating what fault has occurred.</param>
        protected ApplicationResponse(int statusCode)
        {
            IsSuccess = false;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets a value indicating whether an operation was successful.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets a value indicating what status code is present.
        /// </summary>
        [JsonIgnore]
        public int StatusCode { get; private set; }
    }
}
