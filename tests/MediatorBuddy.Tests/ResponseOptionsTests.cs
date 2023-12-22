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
