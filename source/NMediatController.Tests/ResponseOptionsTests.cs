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
        /// Ensures the OkObject Result has the correct properties.
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
        /// Ensures the OkResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void OkResponse_IsCorrect()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());

            var result = ResponseOptions.OkResponse<TestResponse>().Invoke(response);

            Assert.IsInstanceOfType<OkResult>(result);
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

        /// <summary>
        /// Ensures the CreatedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtAction_IsCorrect()
        {
            const string value = "value";
            var response = Envelope<TestResponse>.Success(new TestResponse { Value = value });
            const string action = "action";
            const string controller = "controller";

            var result = ResponseOptions.CreatedAtActionResponse<TestResponse>(
                action,
                controller,
                res => new { Id = res.Value })
                .Invoke(response);

            Assert.IsInstanceOfType<CreatedAtActionResult>(result);
            var asResponse = result as CreatedAtActionResult;
            Assert.AreEqual(action, asResponse?.ActionName);
            Assert.AreEqual(controller, asResponse?.ControllerName);
            Assert.AreEqual(value, asResponse?.RouteValues["Id"]);
            Assert.AreEqual(response.Response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the CreatedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtRoute_IsCorrect()
        {
            const string value = "value";
            var response = Envelope<TestResponse>.Success(new TestResponse { Value = value });

            var result = ResponseOptions.CreatedAtRouteResponse<TestResponse>(res => new { Id = res.Value }).Invoke(response);

            Assert.IsInstanceOfType<CreatedAtRouteResult>(result);
            var asResponse = result as CreatedAtRouteResult;
            Assert.AreEqual(value, asResponse?.RouteValues["Id"]);
            Assert.AreEqual(response.Response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the CreatedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtRouteWithRouteName_IsCorrect()
        {
            const string value = "value";
            var response = Envelope<TestResponse>.Success(new TestResponse { Value = value });
            const string routeName = "routeName";

            var result = ResponseOptions.CreatedAtRouteResponse<TestResponse>(routeName, res => new { Id = res.Value }).Invoke(response);

            Assert.IsInstanceOfType<CreatedAtRouteResult>(result);
            var asResponse = result as CreatedAtRouteResult;
            Assert.AreEqual(routeName, asResponse?.RouteName);

            Assert.AreEqual(value, asResponse?.RouteValues["Id"]);
            Assert.AreEqual(response.Response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void Accepted_IsCorrected()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());

            var result = ResponseOptions.AcceptedResponse<TestResponse>().Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocation_IsCorrected()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response.Response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedStringLocation_IsCorrected()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedResponse<TestResponse>(uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.AreEqual(response.Response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtAction_IsCorrect()
        {
            const string value = "value";
            var response = Envelope<TestResponse>.Success(new TestResponse { Value = value });
            const string action = "action";
            const string controller = "controller";

            var result = ResponseOptions.AcceptedAtActionResponse<TestResponse>(
                    action,
                    controller,
                    res => new { Id = res.Value })
                .Invoke(response);

            Assert.IsInstanceOfType<AcceptedAtActionResult>(result);
            var asResponse = result as AcceptedAtActionResult;
            Assert.AreEqual(action, asResponse?.ActionName);
            Assert.AreEqual(controller, asResponse?.ControllerName);
            Assert.AreEqual(value, asResponse?.RouteValues["Id"]);
            Assert.AreEqual(response.Response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtRouteWithRouteName_IsCorrect()
        {
            const string value = "value";
            var response = Envelope<TestResponse>.Success(new TestResponse { Value = value });
            const string routeName = "routeName";

            var result = ResponseOptions.AcceptedAtRouteResponse<TestResponse>(routeName, res => new { Id = res.Value }).Invoke(response);

            Assert.IsInstanceOfType<AcceptedAtRouteResult>(result);
            var asResponse = result as AcceptedAtRouteResult;
            Assert.AreEqual(routeName, asResponse?.RouteName);

            Assert.AreEqual(value, asResponse?.RouteValues["Id"]);
            Assert.AreEqual(response.Response, asResponse?.Value);
        }
    }
}
