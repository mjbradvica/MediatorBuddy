// <copyright file="ResponseOptionsTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="ResponseOptions"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ResponseOptionsTests
    {
        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedUriResult_IsCorrect()
        {
            var response = new TestResponse();
            var location = new Uri("https://www.myLocation.com");

            var result = ResponseOptions.CreatedResponse<TestResponse>(location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location.ToString(), (result as CreatedResult)?.Location);
        }

        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedUriFuncResult_IsCorrect()
        {
            var response = new TestResponse { Value = "123" };
            var location = new Uri($"https://www.myLocation.com/{response.Value}");

            var result = ResponseOptions.CreatedResponse<TestResponse>(_ => location).Invoke(response);

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
            var response = new TestResponse();
            const string location = "www.myLocation.com";

            var result = ResponseOptions.CreatedResponse<TestResponse>(location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location, (result as CreatedResult)?.Location);
        }

        /// <summary>
        /// Ensures the Created Result has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedStringFuncResult_IsCorrect()
        {
            var response = new TestResponse { Value = "123" };
            var location = $"www.myLocation.com/{response.Value}";

            var result = ResponseOptions.CreatedResponse<TestResponse>(_ => location).Invoke(response);

            Assert.IsInstanceOfType<CreatedResult>(result);
            Assert.AreEqual(response, (result as CreatedResult)?.Value);
            Assert.AreEqual(location, (result as CreatedResult)?.Location);
        }

        /// <summary>
        /// Ensures the CreatedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtAction_IsCorrect()
        {
            const string value = "value";
            var response = new TestResponse { Value = value };
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
            Assert.AreEqual(value, asResponse?.RouteValues?["Id"]);
            Assert.AreEqual(response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the CreatedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtRoute_IsCorrect()
        {
            const string value = "value";
            var response = new TestResponse { Value = value };

            var result = ResponseOptions.CreatedAtRouteResponse<TestResponse>(res => new { Id = res.Value }).Invoke(response);

            Assert.IsInstanceOfType<CreatedAtRouteResult>(result);
            var asResponse = result as CreatedAtRouteResult;
            Assert.AreEqual(value, asResponse?.RouteValues?["Id"]);
            Assert.AreEqual(response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the CreatedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtRouteWithRouteName_IsCorrect()
        {
            const string value = "value";
            var response = new TestResponse { Value = value };
            const string routeName = "routeName";

            var result = ResponseOptions.CreatedAtRouteResponse<TestResponse>(routeName, res => new { Id = res.Value }).Invoke(response);

            Assert.IsInstanceOfType<CreatedAtRouteResult>(result);
            var asResponse = result as CreatedAtRouteResult;
            Assert.AreEqual(routeName, asResponse?.RouteName);

            Assert.AreEqual(value, asResponse?.RouteValues?["Id"]);
            Assert.AreEqual(response, asResponse?.Value);
        }
    }
}
