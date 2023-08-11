namespace NMediatController
{
    /// <summary>
    /// Base interface for all application responses.
    /// </summary>
    public interface IApplicationResponse
    {
        /// <summary>
        /// Gets a value indicating whether an operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating what status code is present.
        /// </summary>
        public int StatusCode { get; }
    }
}
