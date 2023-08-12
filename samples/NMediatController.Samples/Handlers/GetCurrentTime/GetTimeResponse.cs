namespace NMediatController.Samples.Handlers.GetCurrentTime
{
    /// <summary>
    /// Response object for getting the current time.
    /// </summary>
    public class GetTimeResponse
    {
        /// <summary>
        /// Gets a value indicating the current time.
        /// </summary>
        public DateTime TimeStamp { get; } = DateTime.UtcNow;
    }
}
