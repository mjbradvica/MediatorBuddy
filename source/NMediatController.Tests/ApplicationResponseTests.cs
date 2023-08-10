using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NMediatController.Tests
{
    /// <summary>
    /// Tests the <see cref="ApplicationResponse"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ApplicationResponseTests
    {
        /// <summary>
        /// Ensures the default constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_HasCorrectProperties()
        {
            var response = new TestApplicationResponse();

            Assert.IsTrue(response.IsSuccess);
            Assert.AreEqual(ApplicationStatus.Success, response.StatusCode);
        }

        /// <summary>
        /// Ensures the status code constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void StatusCodeConstructor_HasCorrectProperties()
        {
            const int statusCode = 201;

            var response = new TestApplicationResponse(statusCode);

            Assert.IsFalse(response.IsSuccess);
            Assert.AreEqual(statusCode, response.StatusCode);
        }
    }
}
