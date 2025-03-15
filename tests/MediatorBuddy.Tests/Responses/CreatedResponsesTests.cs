// <copyright file="CreatedResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Created responses.
    /// </summary>
    [TestClass]
    public class CreatedResponsesTests
    {
        /// <summary>
        /// Ensures the CreatedResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void CreatedEmpty_IsCorrect()
        {
            var result = ResponseOptions.CreatedEmptyResponse<TestResponse>().Invoke(new TestResponse());

            var asResult = result as CreatedResult;

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(string.Empty, asResult?.Location);
            Assert.IsNull(asResult?.Value);
        }

        /// <summary>
        /// Ensures the CreatedResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void CreatedEmptyLocation_IsCorrect()
        {
            var result = ResponseOptions.CreatedResponse<TestResponse>().Invoke(new TestResponse());

            var asResult = result as CreatedResult;

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(string.Empty, asResult?.Location);
            Assert.IsNotNull(asResult?.Value);
        }

        /// <summary>
        /// Ensures the CreatedResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void CreatedResponse_Response_IsCorrect()
        {
            var location = TestHelpers.UriLocation();
            var response = new TestResponse();

            var result = ResponseOptions.CreatedResponse<TestResponse>(_ => location).Invoke(response);

            var asResult = result as CreatedResult;

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(location.ToString(), asResult?.Location);
            Assert.AreEqual(response, asResult?.Value);
        }

        /// <summary>
        /// Ensures the CreatedResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void CreatedResponse_ResponseFunc_IsCorrect()
        {
            var location = TestHelpers.UriLocation();
            var response = new TestResponse();

            var result = ResponseOptions.CreatedResponse<TestResponse>(_ => (location, response)).Invoke(response);

            var asResult = result as CreatedResult;

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(location.ToString(), asResult?.Location);
            Assert.AreEqual(response, asResult?.Value);
        }
    }
}
