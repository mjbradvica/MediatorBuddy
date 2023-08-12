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
            var result = ResponseOptions.ContinueResponse<TestResponse>().Invoke(Envelope<TestResponse>.Success(new TestResponse()));

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status100Continue, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the Switching Protocols Result has the correct properties..
        /// </summary>
        [TestMethod]
        public void SwitchingProtocolsResult_IsCorrect()
        {
            var result = ResponseOptions.SwitchingProtocolsResponse<TestResponse>().Invoke(Envelope<TestResponse>.Success(new TestResponse()));

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status101SwitchingProtocols, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the Processing Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void ProcessingResult_IsCorrect()
        {
            var result = ResponseOptions.ProcessingResponse<TestResponse>().Invoke(Envelope<TestResponse>.Success(new TestResponse()));

            Assert.IsInstanceOfType<StatusCodeResult>(result);
            Assert.AreEqual(StatusCodes.Status102Processing, (result as StatusCodeResult)?.StatusCode);
        }

        /// <summary>
        /// Ensures the OkObject Result has the correct properties..
        /// </summary>
        [TestMethod]
        public void OkObjectResult_IsCorrect()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());

            var result = ResponseOptions.OkObjectResponse<TestResponse>().Invoke(response);

            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.AreEqual(response.Response, (result as OkObjectResult)?.Value);
        }

        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedUriResult_IsCorrect()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());
            var location = new Uri("https://www.myLocation.com");

            var result = ResponseOptions.CreatedResponse<TestResponse>(location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response.Response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location.ToString(), (result as CreatedResult)?.Location);
        }

        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedStringResult_IsCorrect()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());
            const string location = "www.myLocation.com";

            var result = ResponseOptions.CreatedResponse<TestResponse>(location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response.Response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location, (result as CreatedResult)?.Location);
        }
    }
}
