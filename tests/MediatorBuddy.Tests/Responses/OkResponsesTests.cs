// <copyright file="OkResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Ok responses.
    /// </summary>
    [TestClass]
    public class OkResponsesTests
    {
        /// <summary>
        /// Ensures the OkEmpty has the correct properties.
        /// </summary>
        [TestMethod]
        public void OkEmpty_IsCorrect()
        {
            var result = ResponseOptions.OkEmpty<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<OkResult>(result);
        }

        /// <summary>
        /// Ensures the OkResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void OkResponse_StaticObject_IsCorrect()
        {
            object response = string.Empty;

            var result = ResponseOptions.OkResponse<TestResponse>(response).Invoke(new TestResponse());

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response, (result as OkObjectResult)?.Value);
        }

        /// <summary>
        /// Ensures the OkResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void OkResponse_ResponseObject_IsCorrect()
        {
            var response = new TestResponse();

            var result = ResponseOptions.OkResponse<TestResponse>().Invoke(response);

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response, (result as OkObjectResult)?.Value);
        }

        /// <summary>
        /// Ensures the OkResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void OkResponse_ResponseObjectFunc_IsCorrect()
        {
            var response = new TestResponse();

            var result = ResponseOptions.OkResponse<TestResponse>(_ => response).Invoke(response);

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response, (result as OkObjectResult)?.Value);
        }
    }
}
