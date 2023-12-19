// <copyright file="AcceptedResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Accepted responses.
    /// </summary>
    [TestClass]
    public class AcceptedResponsesTests
    {
        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedEmpty_IsCorrect()
        {
            var result = ResponseOptions.AcceptedEmpty<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.IsNull((result as AcceptedResult)?.Location);
            Assert.IsNull((result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedResponse_Object_IsCorrect()
        {
            object response = string.Empty;

            var result = ResponseOptions.AcceptedResponse<TestResponse>(response).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.IsNull((result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedResponse_Response_IsCorrect()
        {
            var response = new TestResponse();

            var result = ResponseOptions.AcceptedResponse<TestResponse>().Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.IsNull((result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void Accepted_ObjectFunc_IsCorrect()
        {
            var response = new TestResponse();

            var result = ResponseOptions.AcceptedResponse<TestResponse>(x => x).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.IsNull((result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult as the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedEmpty_StringLocation_IsCorrect()
        {
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedEmpty<TestResponse>(uri).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.IsNull((result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedEmpty_StringLocationFunc_IsCorrect()
        {
            var response = new TestResponse();
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedEmpty<TestResponse>(_ => uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.IsNull((result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void Accepted_StringLocationStaticObject_IsCorrect()
        {
            var response = new TestResponse();
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedResponse<TestResponse>(uri, response).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void Accepted_StringLocation_IsCorrect()
        {
            var response = new TestResponse();
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedResponse<TestResponse>(uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedResponse_StringLocationFunc_IsCorrect()
        {
            var response = new TestResponse();
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedResponse<TestResponse>(_ => uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedResponse_StringLocationObjectFunc_IsCorrect()
        {
            var response = new TestResponse();
            const string uri = "https://www.mylocation.com";

            var result = ResponseOptions.AcceptedResponse<TestResponse>(_ => (uri, response)).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri, (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedEmpty_UriLocation_IsCorrect()
        {
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedEmpty<TestResponse>(uri).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.IsNull((result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedEmpty_UriLocationFunc_IsCorrect()
        {
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedEmpty<TestResponse>(_ => uri).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.IsNull((result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocationStaticObject_IsCorrect()
        {
            object response = string.Empty;
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(uri, response).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocation_IsCorrect()
        {
            var response = new TestResponse();
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocationFunc_IsCorrect()
        {
            var response = new TestResponse();
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(_ => uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocationObjectFunc_IsCorrect()
        {
            object response = string.Empty;
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(_ => (uri, response)).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtAction_IsCorrect()
        {
            const string value = "value";
            var response = new TestResponse { Value = value };
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
            Assert.AreEqual(value, asResponse?.RouteValues?["Id"]);
            Assert.AreEqual(response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtRouteWithRouteName_IsCorrect()
        {
            const string value = "value";
            var response = new TestResponse { Value = value };
            const string routeName = "routeName";

            var result = ResponseOptions.AcceptedAtRouteResponse<TestResponse>(routeName, res => new { Id = res.Value }).Invoke(response);

            Assert.IsInstanceOfType<AcceptedAtRouteResult>(result);
            var asResponse = result as AcceptedAtRouteResult;
            Assert.AreEqual(routeName, asResponse?.RouteName);

            Assert.AreEqual(value, asResponse?.RouteValues?["Id"]);
            Assert.AreEqual(response, asResponse?.Value);
        }
    }
}
