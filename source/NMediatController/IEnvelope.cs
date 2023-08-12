namespace NMediatController
{
    /// <summary>
    /// Base interface for all application responses.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public interface IEnvelope<out TResponse>
    {
        /// <summary>
        /// Gets a value indicating what status code is present.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets a value indicating the Response.
        /// </summary>
        public TResponse Response { get; }
    }
}
