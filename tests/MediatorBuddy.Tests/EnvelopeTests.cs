// <copyright file="EnvelopeTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="Envelope{T}"/> class capabilities.
    /// </summary>
    [TestClass]
    public class EnvelopeTests
    {
        /// <summary>
        /// Ensures the default constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_HasCorrectProperties()
        {
            var response = new TestResponse();

            var envelope = Envelope<TestResponse>.Success(response);

            Assert.AreEqual(ApplicationStatus.Success, envelope.StatusCode);
            Assert.AreEqual(string.Empty, envelope.Title);
            Assert.AreEqual(string.Empty, envelope.Detail);
            Assert.AreEqual(response, envelope.Response);
        }

        /// <summary>
        /// Ensures the status code constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void StatusCodeConstructor_HasCorrectProperties()
        {
            const int statusCode = 201;
            const string title = "error";
            const string detail = "an error occurred";

            var envelope = Envelope<TestResponse>.Failure(statusCode, title, detail);

            Assert.AreEqual(statusCode, envelope.StatusCode);
            Assert.IsNull(envelope.Response);
            Assert.AreEqual(title, envelope.Title);
            Assert.AreEqual(detail, envelope.Detail);
        }

        /// <summary>
        /// Ensures the default failure method has the correct properties.
        /// </summary>
        [TestMethod]
        public void StatusCodeConstructor_HasCorrectDefaultProperties()
        {
            const int statusCode = 201;
            const string title = "A failure occurred.";
            const string detail = "No details are available for the failure.";

            var envelope = Envelope<TestResponse>.Failure(statusCode);

            Assert.AreEqual(statusCode, envelope.StatusCode);
            Assert.IsNull(envelope.Response);
            Assert.AreEqual(title, envelope.Title);
            Assert.AreEqual(detail, envelope.Detail);
        }
    }
}
