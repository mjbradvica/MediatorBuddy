using System;
using MediatorBuddy.AspNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="ErrorResponse"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ErrorResponseTests
    {
        /// <summary>
        /// Ensures the object has the correct properties.
        /// </summary>
        [TestMethod]
        public void ErrorResponse_HasCorrectProperties()
        {
            var type = new Uri("/errors/general", UriKind.Relative);
            const string title = "error";
            const int status = 304;
            const string detail = "an error occurred";
            var instance = new Uri("/people", UriKind.Relative);

            var errorResponse = new ErrorResponse(type, title, status, detail, instance);

            Assert.AreEqual(type, errorResponse.Type);
            Assert.AreEqual(title, errorResponse.Title);
            Assert.AreEqual(status, errorResponse.Status);
            Assert.AreEqual(detail, errorResponse.Detail);
            Assert.AreEqual(instance, errorResponse.Instance);
        }

        /// <summary>
        /// Ensures the method returns an instance with the correct properties.
        /// </summary>
        [TestMethod]
        public void FromEnvelope_HasCorrectProperties()
        {
            var type = new Uri("/errors/general", UriKind.Relative);
            const string title = "error";
            const int status = 304;
            const string detail = "an error occurred";
            var instance = new Uri("/people", UriKind.Relative);

            var errorResponse = ErrorResponse.FromEnvelope(type, Envelope<TestResponse>.Failure(status, title, detail), instance);

            Assert.AreEqual(type, errorResponse.Type);
            Assert.AreEqual(title, errorResponse.Title);
            Assert.AreEqual(status, errorResponse.Status);
            Assert.AreEqual(detail, errorResponse.Detail);
            Assert.AreEqual(instance, errorResponse.Instance);
        }
    }
}
