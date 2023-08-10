namespace NMediatController.Tests
{
    /// <summary>
    /// Test class for <see cref="ApplicationResponse"/>.
    /// </summary>
    internal class TestApplicationResponse : ApplicationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestApplicationResponse"/> class.
        /// </summary>
        public TestApplicationResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestApplicationResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The status code used for a failure.</param>
        public TestApplicationResponse(int statusCode)
            : base(statusCode)
        {
        }
    }
}
