namespace NMediatController.Tests
{
    /// <summary>
    /// A test response used for unit testing.
    /// </summary>
    public class TestResponse : ApplicationResponse
    {
        /// <summary>
        /// Gets or sets a Value for the response.
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}
