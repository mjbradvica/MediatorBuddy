// <copyright file="InformationResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Information responses.
    /// </summary>
    [TestClass]
    public class InformationResponsesTests
    {
        /// <summary>
        /// Ensures the Continue Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void ContinueResult_IsCorrect()
        {
            var result = ResponseOptions.ContinueResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status100Continue, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the Switching Protocols Result has the correct properties..
        /// </summary>
        [TestMethod]
        public void SwitchingProtocolsResult_IsCorrect()
        {
            var result = ResponseOptions.SwitchingProtocolsResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status101SwitchingProtocols, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the Processing Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void ProcessingResult_IsCorrect()
        {
            var result = ResponseOptions.ProcessingResponse<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status102Processing, (result as StatusCodeResult)?.StatusCode);
        }
    }
}
