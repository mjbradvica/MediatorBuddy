using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediatController.ASPNET;

namespace NMediatController.Tests
{
    /// <summary>
    /// Tests the <see cref="ResponseOptions"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ResponseOptionsTests
    {
        /// <summary>
        /// Ensures the Continue Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void ContinueResult_IsCorrect()
        {
            var result = ResponseOptions.ContinueResponse().Invoke(new TestApplicationResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status100Continue, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the Switching Protocols Result has the correct properties..
        /// </summary>
        [TestMethod]
        public void SwitchingProtocolsResult_IsCorrect()
        {
            var result = ResponseOptions.SwitchingProtocolsResponse().Invoke(new TestApplicationResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status101SwitchingProtocols, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the Processing Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void ProcessingResult_IsCorrect()
        {
            var result = ResponseOptions.ProcessingResponse().Invoke(new TestApplicationResponse());

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status102Processing, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the OkObject Result has the correct properties..
        /// </summary>
        [TestMethod]
        public void OkObjectResult_IsCorrect()
        {
            var response = new TestApplicationResponse();

            var result = ResponseOptions.OkObjectResponse().Invoke(response);

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response, (result as OkObjectResult)?.Value);
        }

        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedUriResult_IsCorrect()
        {
            var response = new TestApplicationResponse();
            var location = new Uri("https://www.myLocation.com");

            var result = ResponseOptions.CreatedResponse(location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location.ToString(), (result as CreatedResult)?.Location);
        }

        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedStringResult_IsCorrect()
        {
            var response = new TestApplicationResponse();
            const string location = "www.myLocation.com";

            var result = ResponseOptions.CreatedResponse(location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location, (result as CreatedResult)?.Location);
        }
    }
}
