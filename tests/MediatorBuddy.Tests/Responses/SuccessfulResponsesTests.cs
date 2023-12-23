// <copyright file="SuccessfulResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for successful responses.
    /// </summary>
    [TestClass]
    public class SuccessfulResponsesTests
    {
        /// <summary>
        /// Ensures the StatusCodeResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void NonAuthoritative_IsCorrect()
        {
            var result = ResponseOptions.NonAuthoritativeResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status203NonAuthoritative, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the NoContentResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void NoContentResult_IsCorrect()
        {
            var result = ResponseOptions.NoContentResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<NoContentResult>(result);
        }

        /// <summary>
        /// Ensures the ResetContent result is correct.
        /// </summary>
        [TestMethod]
        public void ResetContent_IsCorrect()
        {
            var result = ResponseOptions.ResetContentResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status205ResetContent, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the PartialContent result is correct.
        /// </summary>
        [TestMethod]
        public void PartialContent_IsCorrect()
        {
            var result = ResponseOptions.PartialContentResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status206PartialContent, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the MultiStatus result is correct.
        /// </summary>
        [TestMethod]
        public void MultiStatus_IsCorrect()
        {
            var result = ResponseOptions.MultiStatusResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status207MultiStatus, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the AlreadyReported result is correct.
        /// </summary>
        [TestMethod]
        public void AlreadyReported_IsCorrect()
        {
            var result = ResponseOptions.AlreadyReportedResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status208AlreadyReported, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the AlreadyReported result is correct.
        /// </summary>
        [TestMethod]
        public void IMUsed_IsCorrect()
        {
            var result = ResponseOptions.IMUsedResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status226IMUsed, (result as StatusCodeResult)?.StatusCode);
        }
    }
}
